using CapitalPlacementTask.Infrastructure.Implementation;
using CapitalPlacementTask.Infrastructure.Implementations;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.UnitTests.ApplicationFormTest
{
    public class ApplicationFormServiceFactory
    {
        public readonly Mock<Container> ApplicationFormContainer = new();
        public readonly Mock<Container> ProgramDetailContainer = new();
        public readonly Mock<Container> PersonalInformationContainer = new();
        public readonly Mock<Container> ProfileContainer = new();
        public readonly Mock<Container> EducationContainer = new();
        public readonly Mock<Container> WorkExperienceContainer = new();

        public ApplicationFormServiceFactory()
        {
            var cosmosClientMock = new Mock<CosmosClient>();
            var configurationMock = new Mock<IConfiguration>();
            cosmosClientMock.Setup(c => c.GetContainer(It.IsAny<string>(), "ProgramDetails")).Returns(ProgramDetailContainer.Object);
            cosmosClientMock.Setup(c => c.GetContainer(It.IsAny<string>(), "ApplicationForms")).Returns(ApplicationFormContainer.Object);
            cosmosClientMock.Setup(c => c.GetContainer(It.IsAny<string>(), "PersonalInformations")).Returns(PersonalInformationContainer.Object);
            cosmosClientMock.Setup(c => c.GetContainer(It.IsAny<string>(), "Profiles")).Returns(ProfileContainer.Object);
            cosmosClientMock.Setup(c => c.GetContainer(It.IsAny<string>(), "Educations")).Returns(EducationContainer.Object);
            cosmosClientMock.Setup(c => c.GetContainer(It.IsAny<string>(), "WorkExperience")).Returns(WorkExperienceContainer.Object);
            ApplicationFormService = new ApplicationFormService(cosmosClientMock.Object, configurationMock.Object);
        }

        public ApplicationFormService ApplicationFormService { get; set; }
    }
}
