using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Application.Interfaces;
using CapitalPlacementTask.Application.Models.Enums;
using CapitalPlacementTask.Application.Utils;
using CapitalPlacementTask.Domain.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;

namespace CapitalPlacementTask.Infrastructure.Implementation 
{
    public class ProgramDetailService : IProgramDetailService
    {
        private readonly Container _programDetailContainer;
        
        public ProgramDetailService(CosmosClient cosmosClient, IConfiguration configuration)
        {
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            _programDetailContainer = cosmosClient.GetContainer(databaseName, "ProgramDetails");
        }

        public async Task<ResultModel<List<ProgramDetailDTO>>> AllProgramDetails()
        {
            var iterator = _programDetailContainer.GetItemLinqQueryable<ProgramDetail>().ToFeedIterator();
            var programDetails = new List<ProgramDetail>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                programDetails.AddRange(response);
            }

            var data = programDetails.OrderByDescending(x => x.CreatedOn).Select(x => (ProgramDetailDTO)x).ToList();
            return new ResultModel<List<ProgramDetailDTO>>(data, $"Found {data.Count} program details", ApiResponseCode.OK);
        }

        public async Task<ResultModel<bool>> CreateProgramDetail(CreateProgramDTO model)
        {
            var data = new ProgramDetail
            {
                Id = Guid.NewGuid(),
                ProgramTitle = model.ProgramTitle,
                ProgramSummary = model.ProgramSummary,
                ProgramDescription = model.ProgramDescription,
                RequiredSkills = model.RequiredSkills,
                ProgramBenefits = model.ProgramBenefits,
                ApplicationCriteria = model.ApplicationCriteria,
                ProgramType = model.ProgramType,
                ProgramStart = model.ProgramStart,
                ApplicationOpen = model.ApplicationOpen,
                Duration = model.Duration,
                ProgramLocation = model.ProgramLocation,
                MinimumQualifications = model.MinimumQualifications,
                NumberOfApplication = model.NumberOfApplication
            };

            await _programDetailContainer.CreateItemAsync(data);
            return new ResultModel<bool>(true, "Successfully Created a program details", ApiResponseCode.CREATED);
        }

        public async Task<ResultModel<bool>> DeleteProgramDetail(Guid id)
        {
            var resultModel = new ResultModel<bool>();

            var programDetail = await _programDetailContainer.ReadItemAsync<ProgramDetail>(id.ToString(), new PartitionKey(id.ToString()));
           
            if (programDetail.Resource is null)
            {
                resultModel.AddError("Program details doesn't exists");
                return resultModel;
            }

            await _programDetailContainer.DeleteItemAsync<ProgramDetail>(id.ToString(), new PartitionKey(id.ToString()));

            resultModel.Data = true;
            resultModel.ApiResponseCode = ApiResponseCode.OK;
            return resultModel;

        }

        public async Task<ResultModel<ProgramDetailDTO>> GetProgramDetail(Guid id)
        {
            var resultModel = new ResultModel<ProgramDetailDTO>();

            var programDetail = await _programDetailContainer.ReadItemAsync<ProgramDetail>(id.ToString(), new PartitionKey(id.ToString()));

            if (programDetail.Resource is null)
            {
                resultModel.AddError("Program details doesn't exists");
                return resultModel;
            }

            ProgramDetailDTO programDetailDTO = programDetail.Resource;
            return new ResultModel<ProgramDetailDTO>(programDetailDTO, "Successfully found a program details", ApiResponseCode.OK);
            
        }

        public async Task<ResultModel<bool>> UpdateProgramDetail(UpdateProgramDetailDTO model, Guid id)
        {
            var resultModel = new ResultModel<bool>();

            var programDetail = await _programDetailContainer.ReadItemAsync<ProgramDetail>(id.ToString(), new PartitionKey(id.ToString()));

            if (programDetail.Resource is null)
            {
                resultModel.AddError("Program details doesn't exists");
                return resultModel;
            }

            programDetail.Resource.ProgramTitle = string.IsNullOrWhiteSpace(model.ProgramTitle) ? programDetail.Resource.ProgramTitle : model.ProgramTitle;
            programDetail.Resource.ProgramSummary = string.IsNullOrWhiteSpace(model.ProgramSummary) ? programDetail.Resource.ProgramSummary : model.ProgramSummary;
            programDetail.Resource.ProgramDescription = string.IsNullOrWhiteSpace(model.ProgramDescription) ? programDetail.Resource.ProgramDescription : model.ProgramDescription;
            programDetail.Resource.RequiredSkills = string.IsNullOrWhiteSpace(model.RequiredSkills) ? programDetail.Resource.RequiredSkills : model.RequiredSkills;
            programDetail.Resource.ProgramBenefits = string.IsNullOrWhiteSpace(model.ProgramBenefits) ? programDetail.Resource.ProgramBenefits : model.ProgramBenefits;
            programDetail.Resource.ApplicationCriteria = string.IsNullOrWhiteSpace(model.ApplicationCriteria) ? programDetail.Resource.ApplicationCriteria : model.ApplicationCriteria;
            programDetail.Resource.ProgramType = string.IsNullOrWhiteSpace(model.ProgramType) ? programDetail.Resource.ProgramType : model.ProgramType;
            programDetail.Resource.ProgramStart = model.ProgramStart;
            programDetail.Resource.ApplicationOpen = model.ApplicationOpen;
            programDetail.Resource.Duration = string.IsNullOrWhiteSpace(model.Duration) ? programDetail.Resource.Duration : model.Duration;
            programDetail.Resource.ProgramLocation = string.IsNullOrWhiteSpace(model.ProgramLocation) ? programDetail.Resource.ProgramLocation : model.ProgramLocation;
            programDetail.Resource.MinimumQualifications = string.IsNullOrWhiteSpace(model.MinimumQualifications) ? programDetail.Resource.MinimumQualifications : model.MinimumQualifications;
            programDetail.Resource.NumberOfApplication = model.NumberOfApplication;
            programDetail.Resource.ModifiedOn = DateTime.UtcNow;

            await _programDetailContainer.ReplaceItemAsync(programDetail.Resource, programDetail.Resource.Id.ToString());

            resultModel.Data = true;
            resultModel.Message = "Successfully updated a program details";
            resultModel.ApiResponseCode = ApiResponseCode.OK;

            return resultModel;

        }
    }
}
