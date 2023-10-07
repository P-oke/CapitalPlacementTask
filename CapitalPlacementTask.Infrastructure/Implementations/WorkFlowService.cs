using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Application.DTOs.WorkFlowDTOs;
using CapitalPlacementTask.Application.Interfaces;
using CapitalPlacementTask.Application.Models.Enums;
using CapitalPlacementTask.Application.Utils;
using CapitalPlacementTask.Domain.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.Infrastructure.Implementations
{
    public class WorkFlowService : IWorkFlowService
    {
        private readonly IConfiguration _configuration;
        private readonly Container _workFlowContainer;

        public WorkFlowService(CosmosClient cosmosClient, IConfiguration configuration)
        {
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            _configuration = configuration;
            _workFlowContainer = cosmosClient.GetContainer(databaseName, "WorkFlows");
        }

        public async Task<ResultModel<bool>> CreateWorkFlow(CreateWorkFlowDTO model)
        {
            var videoInterviewId = Guid.NewGuid();

            var workFlow = new WorkFlow
            {
                Id = Guid.NewGuid(),
                StageName = model.StageName,
                StageType = model.StageType,
                VideoInterviewId = videoInterviewId
            };
    

            if (model.StageType == Domain.Enum.StageType.VideoInterview)
            {
                workFlow.VideoInterview = new VideoInterview
                {
                    Id = videoInterviewId,
                    Question = model.CreateVideoInterview?.Question,
                    VideoDescription = model.CreateVideoInterview?.VideoDescription,
                    VideoDuration = model.CreateVideoInterview!.VideoDuration,
                    DeadlineSubmission = model.CreateVideoInterview!.DeadlineSubmission
                };
            }

            await _workFlowContainer.CreateItemAsync(workFlow);
            return new ResultModel<bool>(true, "Successfully Created a work flow", ApiResponseCode.CREATED);
        }

        public async Task<ResultModel<bool>> DeleteWorkFlow(Guid id)
        {
            var resultModel = new ResultModel<bool>();

            var programDetail = await _workFlowContainer.ReadItemAsync<WorkFlow>(id.ToString(), new PartitionKey(id.ToString()));

            if (programDetail.Resource is null)
            {
                resultModel.AddError("work flow doesn't exists");
                return resultModel;
            }

            await _workFlowContainer.DeleteItemAsync<WorkFlowDTO>(id.ToString(), new PartitionKey(id.ToString()));

            resultModel.Data = true;
            resultModel.ApiResponseCode = ApiResponseCode.OK;
            return resultModel;

        }

        public async Task<ResultModel<WorkFlowDTO>> GetWorkFlow(Guid id)
        {
            var resultModel = new ResultModel<WorkFlowDTO>();

            var workFlow = await _workFlowContainer.ReadItemAsync<WorkFlow>(id.ToString(), new PartitionKey(id.ToString()));

            if (workFlow.Resource is null)
            {
                resultModel.AddError("work flow doesn't exists");
                return resultModel;
            }

            WorkFlowDTO workFlowDTO = workFlow.Resource;
            return new ResultModel<WorkFlowDTO>(workFlowDTO, "Successfully found a program details", ApiResponseCode.OK); throw new NotImplementedException();
        }

        public async Task<ResultModel<bool>> UpdateWorkFlow(UpdateWorkFlowDTO model, Guid id)
        {
            var resultModel = new ResultModel<bool>();

            var workFlow = await _workFlowContainer.ReadItemAsync<WorkFlow>(id.ToString(), new PartitionKey(id.ToString()));

            if (workFlow.Resource is null)
            {
                resultModel.AddError("Program details doesn't exists");
                return resultModel;
            }

            workFlow.Resource.StageName = string.IsNullOrWhiteSpace(model.StageName) ? workFlow.Resource.StageName : model.StageName;
            workFlow.Resource.WorkflowType = model.WorkflowType;
            workFlow.Resource.StageType = model.StageType;

            if (workFlow.Resource.VideoInterview != null)
            {
                workFlow.Resource.VideoInterview.Question = string.IsNullOrWhiteSpace(model.UpdateVideoInterviewDTO.Question)? workFlow.Resource.VideoInterview.Question : model.UpdateVideoInterviewDTO.Question;
                workFlow.Resource.VideoInterview.VideoDescription = string.IsNullOrWhiteSpace(model.UpdateVideoInterviewDTO.VideoDescription) ? workFlow.Resource.VideoInterview.VideoDescription : model.UpdateVideoInterviewDTO.VideoDescription;
                workFlow.Resource.VideoInterview.VideoDuration = model.UpdateVideoInterviewDTO.VideoDuration;
                workFlow.Resource.VideoInterview.DeadlineSubmission = model.UpdateVideoInterviewDTO!.DeadlineSubmission;
            }

            await _workFlowContainer.ReplaceItemAsync(workFlow.Resource, workFlow.Resource.Id.ToString());

            resultModel.Data = true;
            resultModel.Message = "Successfully updated a work flow";
            resultModel.ApiResponseCode = ApiResponseCode.OK;

            return resultModel;
        }
    }
}
