using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs.ApplicationDTOs;
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
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly IConfiguration _configuration;
        private readonly Container _applicationFormContainer;
        private readonly Container _programDetailContainer;
        private readonly Container _personalInformationContainer;
        private readonly Container _profileContainer;
        private readonly Container _educationContainer;
        private readonly Container _workExperienceContainer;

        public ApplicationFormService(CosmosClient cosmosClient, IConfiguration configuration)
        {
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            _configuration = configuration;
            _applicationFormContainer = cosmosClient.GetContainer(databaseName, "ApplicationForms");
            _programDetailContainer = cosmosClient.GetContainer(databaseName, "ProgramDetails");
            _personalInformationContainer = cosmosClient.GetContainer(databaseName, "PersonalInformations");
            _profileContainer = cosmosClient.GetContainer(databaseName, "Profiles");
            _educationContainer = cosmosClient.GetContainer(databaseName, "Educations");
            _workExperienceContainer = cosmosClient.GetContainer(databaseName, "WorkExperiences");
        }

        public async Task<ResultModel<bool>> CreateApplicationForm(CreateApplicationFormDTO model)
        {
            var resultModel = new ResultModel<bool>();

            var programDetail = await _programDetailContainer.ReadItemAsync<ProgramDetail>(model.ProgramDetailId.ToString(), new PartitionKey(model.ProgramDetailId.ToString()));

            if (programDetail.Resource is null)
            {
                resultModel.AddError("Program details doesn't exists");
                return resultModel;
            }

            var applicationFormId = Guid.NewGuid();
            var personalInformationId = Guid.NewGuid();
            var profileId = Guid.NewGuid();
            var educationId = Guid.NewGuid();
            var workExperienceId = Guid.NewGuid();

            var applicationForm = new ApplicationForm
            {
                Id = applicationFormId,
                CoverImage = "",
                PersonalInformation = new PersonalInformation
                {
                    Id = personalInformationId,
                    FirstName = model.CreatePersonalInformationDTO?.FirstName,
                    LastName = model.CreatePersonalInformationDTO?.LastName,
                    Email = model.CreatePersonalInformationDTO?.Email,
                    PhoneNumber = model.CreatePersonalInformationDTO?.PhoneNumber,
                    Nationality = model.CreatePersonalInformationDTO?.Nationality,
                    CurrentResidence = model.CreatePersonalInformationDTO?.CurrentResidence,
                    IdNumber = model.CreatePersonalInformationDTO?.IdNumber,
                    DateOfBirth = model.CreatePersonalInformationDTO!.DateOfBirth,
                    Gender = model.CreatePersonalInformationDTO?.Gender,
                    ApplicationFormId = applicationFormId,
                },
                PersonalInformationId = personalInformationId,
                Profile = new Profile
                {
                    Id = profileId,
                    Education = model.CreateProfileDTO?.CreateEducationDTO.Select(x => new Education
                    {
                        Id = educationId,
                        School = x.School,
                        Degree = x.Degree,
                        CourseName = x.CourseName,
                        SchoolLocation = x.SchoolLocation,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        CurrentlyStudyingThere = x.CurrentlyStudyingThere,
                        ProfileId = profileId,
                    }).ToList(),

                    WorkExperience = model.CreateProfileDTO?.CreateWorkExperienceDTO.Select(x => new WorkExperience
                    {
                        Id = workExperienceId,
                        Company = x.Company,
                        Title = x.Title,
                        LocationOfWork = x.LocationOfWork,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        CurrentlyWorkThere = x.CurrentlyWorkThere,
                        ProfileId = profileId,
                    }).ToList()
                },
                ProfileId = profileId,
                ProgramDetailId = programDetail.Resource.Id            
            };

            await _applicationFormContainer.CreateItemAsync(applicationForm);
            return new ResultModel<bool>(true, "Successfully Created an application form", ApiResponseCode.CREATED);
        }

        public async Task<ResultModel<bool>> DeleteApplicationForm(Guid id)
        {
            var resultModel = new ResultModel<bool>();

            var applicationForm = await _applicationFormContainer.ReadItemAsync<ApplicationForm>(id.ToString(), new PartitionKey(id.ToString()));

            if (applicationForm.Resource is null)
            {
                resultModel.AddError("application form doesn't exists");
                return resultModel;
            }

            await _applicationFormContainer.DeleteItemAsync<ApplicationForm>(id.ToString(), new PartitionKey(id.ToString()));

            resultModel.Data = true;
            resultModel.ApiResponseCode = ApiResponseCode.OK;
            return resultModel;
        }

        public async Task<ResultModel<ApplicationFormDTO>> GetApplicationForm(Guid id)
        {
            var resultModel = new ResultModel<ApplicationFormDTO>();

            var applicationForm = await _applicationFormContainer.ReadItemAsync<ApplicationForm>(id.ToString(), new PartitionKey(id.ToString()));

            if (applicationForm.Resource is null)
            {
                resultModel.AddError("application form doesn't exists");
                return resultModel;
            }

            ApplicationFormDTO applicationFormDTO = applicationForm.Resource;
            resultModel.Data = applicationFormDTO;
            resultModel.ApiResponseCode = ApiResponseCode.OK;
            return resultModel;
        }

        public async Task<ResultModel<bool>> UpdateApplicationForm(UpdateApplicationFormDTO model, Guid id)
        {
            var resultModel = new ResultModel<bool>();

            var applicationForm = await _applicationFormContainer.ReadItemAsync<ApplicationForm>(id.ToString(), new PartitionKey(id.ToString()));

            if (applicationForm.Resource is null)
            {
                resultModel.AddError("application form doesn't exists");
                return resultModel;
            }

            var programDetail = await _programDetailContainer.ReadItemAsync<ProgramDetail>(model.ProgramDetailId.ToString(), new PartitionKey(model.ProgramDetailId.ToString()));

            if (programDetail.Resource is null)
            {
                resultModel.AddError("Program details doesn't exists");
                return resultModel;
            }

            var personalInformation = await _personalInformationContainer.ReadItemAsync<PersonalInformation>(model.PersonalInformationId.ToString(), new PartitionKey(model.PersonalInformationId.ToString()));

            if (personalInformation.Resource is null)
            {
                resultModel.AddError("personal information details doesn't exists");
                return resultModel;
            }

            var profile = await _profileContainer.ReadItemAsync<Profile>(model.ProfileId.ToString(), new PartitionKey(model.ProfileId.ToString()));

            if (profile.Resource is null)
            {
                resultModel.AddError("profile doesn't exists");
                return resultModel;
            }


            foreach (var item in model.UpdateProfileDTO.UpdateEducationDTO)
            {
                var education = await _educationContainer.ReadItemAsync<Education>(item.Id.ToString(), new PartitionKey(item.Id.ToString()));

                if (education.Resource is null)
                {
                    resultModel.AddError("education doesn't exists");
                    return resultModel;
                }
            }

            foreach (var item in model.UpdateProfileDTO.UpdateWorkExperienceDTO)
            {
                var workExperience = await _workExperienceContainer.ReadItemAsync<WorkExperience>(item.Id.ToString(), new PartitionKey(item.Id.ToString()));

                if (workExperience.Resource is null)
                {
                    resultModel.AddError("work experience doesn't exists");
                    return resultModel;
                }
            }  

            applicationForm.Resource.CoverImage = "";
            applicationForm.Resource.PersonalInformation.FirstName = string.IsNullOrWhiteSpace(model.UpdatePersonalInformationDTO.FirstName) ? applicationForm.Resource.PersonalInformation.FirstName : model.UpdatePersonalInformationDTO.FirstName;
            applicationForm.Resource.PersonalInformation.LastName = string.IsNullOrWhiteSpace(model.UpdatePersonalInformationDTO.LastName) ? applicationForm.Resource.PersonalInformation.LastName : model.UpdatePersonalInformationDTO.LastName;
            applicationForm.Resource.PersonalInformation.Email = string.IsNullOrWhiteSpace(model.UpdatePersonalInformationDTO.Email) ? applicationForm.Resource.PersonalInformation.Email : model.UpdatePersonalInformationDTO.Email;
            applicationForm.Resource.PersonalInformation.PhoneNumber = string.IsNullOrWhiteSpace(model.UpdatePersonalInformationDTO.PhoneNumber) ? applicationForm.Resource.PersonalInformation.PhoneNumber : model.UpdatePersonalInformationDTO.PhoneNumber;
            applicationForm.Resource.PersonalInformation.Nationality = string.IsNullOrWhiteSpace(model.UpdatePersonalInformationDTO.Nationality) ? applicationForm.Resource.PersonalInformation.Nationality : model.UpdatePersonalInformationDTO.Nationality;
            applicationForm.Resource.PersonalInformation.CurrentResidence = string.IsNullOrWhiteSpace(model.UpdatePersonalInformationDTO.CurrentResidence) ? applicationForm.Resource.PersonalInformation.CurrentResidence : model.UpdatePersonalInformationDTO.CurrentResidence;
            applicationForm.Resource.PersonalInformation.IdNumber = string.IsNullOrWhiteSpace(model.UpdatePersonalInformationDTO.IdNumber) ? applicationForm.Resource.PersonalInformation.IdNumber : model.UpdatePersonalInformationDTO.IdNumber;
            applicationForm.Resource.PersonalInformation.DateOfBirth = model.UpdatePersonalInformationDTO.DateOfBirth;
            applicationForm.Resource.PersonalInformation.Gender = string.IsNullOrWhiteSpace(model.UpdatePersonalInformationDTO.Gender) ? applicationForm.Resource.PersonalInformation.Gender : model.UpdatePersonalInformationDTO.Gender;
            applicationForm.Resource.Profile.Resume = "";
          

            foreach (var item in model.UpdateProfileDTO.UpdateEducationDTO)
            {
                var education = await _educationContainer.ReadItemAsync<Education>(item.Id.ToString(), new PartitionKey(item.Id.ToString()));

                education.Resource.School = string.IsNullOrWhiteSpace(item.School) ? education.Resource.School : item.School;
                education.Resource.Degree = string.IsNullOrWhiteSpace(item.Degree) ? education.Resource.Degree : item.Degree;
                education.Resource.CourseName = string.IsNullOrWhiteSpace(item.CourseName) ? education.Resource.CourseName : item.CourseName;
                education.Resource.SchoolLocation = string.IsNullOrWhiteSpace(item.SchoolLocation) ? education.Resource.SchoolLocation : item.SchoolLocation;
                education.Resource.StartDate = item.StartDate;
                education.Resource.EndDate = item.EndDate;
                education.Resource.CurrentlyStudyingThere = item.CurrentlyStudyingThere;
                education.Resource.ProfileId = education.Resource.ProfileId;
            }

            foreach (var item in model.UpdateProfileDTO.UpdateWorkExperienceDTO)
            {
                var workExperience = await _workExperienceContainer.ReadItemAsync<WorkExperience>(item.Id.ToString(), new PartitionKey(item.Id.ToString()));
                workExperience.Resource.Company = string.IsNullOrWhiteSpace(item.Company) ? workExperience.Resource.Company : item.Company;
                workExperience.Resource.Title = string.IsNullOrWhiteSpace(item.Title) ? workExperience.Resource.Title : item.Title;
                workExperience.Resource.LocationOfWork = string.IsNullOrWhiteSpace(item.LocationOfWork) ? workExperience.Resource.LocationOfWork : item.LocationOfWork;
                workExperience.Resource.StartDate = item.StartDate;
                workExperience.Resource.EndDate = item.EndDate;
                workExperience.Resource.CurrentlyWorkThere = item.CurrentlyWorkThere;
            }

            await _programDetailContainer.ReplaceItemAsync(applicationForm.Resource, applicationForm.Resource.Id.ToString());

            resultModel.Data = true;
            resultModel.Message = "Successfully updated a work experience details";
            resultModel.ApiResponseCode = ApiResponseCode.OK;

            return resultModel;
        }

    }
}
