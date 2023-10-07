using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.ApplicationDTOs.ApplicationDTOs;
using CapitalPlacementTask.Application.DTOs.ApplicationFormDTOs.EducationDTOs;
using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Domain.Entities;
using Microsoft.Azure.Cosmos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.UnitTests.ApplicationFormTest
{
    public class ApplicationFormServiceTest
    {
        private readonly ApplicationFormServiceFactory _fac;

        public ApplicationFormServiceTest()
        {
            _fac = new ApplicationFormServiceFactory();
            
        }

        [Fact]
        private async Task CreateApplicationForm_ShouldWork()
        {
            //Arrange

            var programDetail = new ProgramDetail
            {
                Id = Guid.Parse("0f4bd353-41a6-4f09-b1c6-380d8c84cd62")
            };

            var data = new CreateApplicationFormDTO
            {
                ProgramDetailId = programDetail.Id,
                CreatePersonalInformationDTO = new(),
                CreateProfileDTO = new()
            };

            var responseMock = new Mock<ItemResponse<ProgramDetail>>();
            responseMock.Setup(x => x.Resource).Returns(programDetail); //expectedItem is of VehicleInfo type


            _fac.ProgramDetailContainer.Setup(c => c.ReadItemAsync<ProgramDetail>(programDetail.Id.ToString(), new PartitionKey(programDetail.Id.ToString()), null, default))
                .ReturnsAsync(responseMock.Object);

            //Act

            var result = await _fac.ApplicationFormService.CreateApplicationForm(data);

            //Assert
            Assert.False(result.HasError);
        }

        [Fact]
        private async Task DeleteApplicationForm_ShouldWork()
        {
            //Arrange
            var applicationForm = new ApplicationForm
            {
                Id = Guid.Parse("d0daafd2-8cfd-44d6-8847-6d910198d5da")
            };

            var responseMock = new Mock<ItemResponse<ApplicationForm>>();
            responseMock.Setup(x => x.Resource).Returns(applicationForm); //expectedItem is of VehicleInfo type


            _fac.ApplicationFormContainer.Setup(c => c.ReadItemAsync<ApplicationForm>(applicationForm.Id.ToString(), new PartitionKey(applicationForm.Id.ToString()), null, default))
                .ReturnsAsync(responseMock.Object);


            //Act

            var result = await _fac.ApplicationFormService.DeleteApplicationForm(applicationForm.Id);

            //Assert
            Assert.False(result.HasError);
        }

        [Fact]
        private async Task GetApplicationForm_ShouldWork() 
        {
            //Arrange
            var applicationForm = new ApplicationForm
            {
                Id = Guid.Parse("d0daafd2-8cfd-44d6-8847-6d910198d5da")
            };

            var responseMock = new Mock<ItemResponse<ApplicationForm>>();
            responseMock.Setup(x => x.Resource).Returns(applicationForm); //expectedItem is of VehicleInfo type


            _fac.ApplicationFormContainer.Setup(c => c.ReadItemAsync<ApplicationForm>(applicationForm.Id.ToString(), new PartitionKey(applicationForm.Id.ToString()), null, default))
                .ReturnsAsync(responseMock.Object);


            //Act

            var result = await _fac.ApplicationFormService.GetApplicationForm(applicationForm.Id);

            //Assert
            Assert.False(result.HasError);
        }

        [Fact]
        private async Task UpdateApplicationForm_ShouldWork()
        {
            //Arrange

            var personalInformation = new PersonalInformation
            {
                Id = Guid.Parse("586606bf-1ebd-45bf-9e3c-d323079a0658")
            };

            var programDetail = new ProgramDetail
            {
                Id = Guid.Parse("9836f4af-a0d8-4a86-b122-71c6fad51531")
            };

            var profile = new Profile
            {
                Id = Guid.Parse("e3c48a27-6db6-439d-906f-661a19b6e355")
            };

            var education = new Education
            {
                Id = Guid.Parse("19dd9a5d-47ec-474d-b136-0a4e4747a86d")
            };

            var applicationForm = new ApplicationForm
            {
                Id = Guid.Parse("d0daafd2-8cfd-44d6-8847-6d910198d5da"),
                PersonalInformationId = personalInformation.Id,
                ProfileId = profile.Id,
                ProgramDetailId = programDetail.Id,
                PersonalInformation = new PersonalInformation
                {
                    Id = personalInformation.Id
                },
                Profile = new Profile
                {
                    Id = profile.Id,
                    Education = new List<Education>
                    {
                        new Education
                        {
                            Id = education.Id,
                            ProfileId = profile.Id
                        }
                    }

                }
            };       

         
            var data = new UpdateApplicationFormDTO
            {
                ProgramDetailId = programDetail.Id,
                ProfileId = profile.Id,
                PersonalInformationId = personalInformation.Id,
                UpdatePersonalInformationDTO = new(),
                UpdateProfileDTO = new()
                {
                    UpdateEducationDTO = new List<UpdateEducationDTO>()
                    {   
                        new UpdateEducationDTO
                        {
                            Id = education.Id
                        }
                    },
                }
            };

            //application form
            var applicationFormresponseMock = new Mock<ItemResponse<ApplicationForm>>();
            applicationFormresponseMock.Setup(x => x.Resource).Returns(applicationForm);


            _fac.ApplicationFormContainer.Setup(c => c.ReadItemAsync<ApplicationForm>(applicationForm.Id.ToString(), new PartitionKey(applicationForm.Id.ToString()), null, default))
                .ReturnsAsync(applicationFormresponseMock.Object);

            //program details
            var programDetailResponseMock = new Mock<ItemResponse<ProgramDetail>>();
            programDetailResponseMock.Setup(x => x.Resource).Returns(programDetail); 


            _fac.ProgramDetailContainer.Setup(c => c.ReadItemAsync<ProgramDetail>(programDetail.Id.ToString(), new PartitionKey(programDetail.Id.ToString()), null, default))
                .ReturnsAsync(programDetailResponseMock.Object);

            
            //personal information
            var personalInformationResponseMock = new Mock<ItemResponse<PersonalInformation>>();
            personalInformationResponseMock.Setup(x => x.Resource).Returns(personalInformation);


            _fac.PersonalInformationContainer.Setup(c => c.ReadItemAsync<PersonalInformation>(personalInformation.Id.ToString(), new PartitionKey(personalInformation.Id.ToString()), null, default))
                .ReturnsAsync(personalInformationResponseMock.Object);

            //profile
            var profileResponseMock = new Mock<ItemResponse<Profile>>();
            profileResponseMock.Setup(x => x.Resource).Returns(profile);


            _fac.ProfileContainer.Setup(c => c.ReadItemAsync<Profile>(profile.Id.ToString(), new PartitionKey(profile.Id.ToString()), null, default))
                .ReturnsAsync(profileResponseMock.Object);

            //profile
            var educationResponseMock = new Mock<ItemResponse<Education>>();
            educationResponseMock.Setup(x => x.Resource).Returns(education);


            _fac.EducationContainer.Setup(c => c.ReadItemAsync<Education>(education.Id.ToString(), new PartitionKey(education.Id.ToString()), null, default))
                .ReturnsAsync(educationResponseMock.Object);


            //Act

            var result = await _fac.ApplicationFormService.UpdateApplicationForm(data, applicationForm.Id);

            //Assert
            Assert.False(result.HasError);
        }

    }
}
