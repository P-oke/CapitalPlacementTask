using CapitalPlacementTask.Application.DTOs.PreviewDTOs;
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
    public class PreviewService : IPreviewService
    {
        private readonly IConfiguration _configuration;
        private readonly Container _previewContainer;

        public PreviewService(CosmosClient cosmosClient, IConfiguration configuration)
        {
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            _configuration = configuration;
            _previewContainer = cosmosClient.GetContainer(databaseName, "Previews");
        }

        public async Task<ResultModel<bool>> CreatePreview(CreatePreviewDTO model)
        {
            var preview = new Preview
            {
                Id = Guid.NewGuid(),
                Description = model.Description,
                ProgramBenefit = model.ProgramBenefit,
                ProgramSkillSet = model.ProgramSkillSet,
                ApplicationCriteria = model.ApplicationCriteria

            };

            await _previewContainer.CreateItemAsync(preview);
            return new ResultModel<bool>(true, "Successfully Created a preview", ApiResponseCode.CREATED);
        }

        public async Task<ResultModel<bool>> DeletePreview(Guid id)
        {
            var resultModel = new ResultModel<bool>();

            var preview = await _previewContainer.ReadItemAsync<Preview>(id.ToString(), new PartitionKey(id.ToString()));

            if (preview.Resource is null)
            {
                resultModel.AddError("Preview doesn't exists");
                return resultModel;
            }

            await _previewContainer.DeleteItemAsync<Preview>(id.ToString(), new PartitionKey(id.ToString()));

            resultModel.Data = true;
            resultModel.ApiResponseCode = ApiResponseCode.OK;
            return resultModel;
        }

        public async Task<ResultModel<PreviewDTO>> GetPreview(Guid id)
        {
            var resultModel = new ResultModel<PreviewDTO>();

            var preview = await _previewContainer.ReadItemAsync<Preview>(id.ToString(), new PartitionKey(id.ToString()));

            if (preview.Resource is null)
            {
                resultModel.AddError("Preview doesn't exists");
                return resultModel;
            }

            PreviewDTO previewDTO = preview.Resource;
            return new ResultModel<PreviewDTO>(previewDTO, "Successfully found a preview", ApiResponseCode.OK);
        }

        public async Task<ResultModel<bool>> UpdatePreview(UpdatePreviewDTO model, Guid id)
        {
            var resultModel = new ResultModel<bool>();

            var preview = await _previewContainer.ReadItemAsync<Preview>(id.ToString(), new PartitionKey(id.ToString()));

            if (preview.Resource is null)
            {
                resultModel.AddError("Preview doesn't exists");
                return resultModel;
            }

            preview.Resource.Description = string.IsNullOrWhiteSpace(model.Description) ? preview.Resource.Description : model.Description;
            preview.Resource.ProgramSkillSet = string.IsNullOrWhiteSpace(model.ProgramSkillSet) ? preview.Resource.ProgramSkillSet : model.Description;
            preview.Resource.ProgramBenefit = string.IsNullOrWhiteSpace(model.ProgramBenefit) ? preview.Resource.ProgramBenefit : model.ProgramBenefit;
            preview.Resource.ApplicationCriteria = string.IsNullOrWhiteSpace(model.ApplicationCriteria) ? preview.Resource.ApplicationCriteria : model.ApplicationCriteria;

            await _previewContainer.ReplaceItemAsync(preview.Resource, preview.Resource.Id.ToString());

            resultModel.Data = true;
            resultModel.Message = "Successfully updated a preview";
            resultModel.ApiResponseCode = ApiResponseCode.OK;

            return resultModel;
        }
    }
}
