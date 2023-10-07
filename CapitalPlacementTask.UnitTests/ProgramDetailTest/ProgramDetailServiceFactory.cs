using CapitalPlacementTask.Infrastructure.Implementation;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.UnitTests.ProgramDetailTest
{
    public class ProgramDetailServiceFactory
    {
      
        public readonly Mock<Container> ProgramDetailContainer = new();

        public ProgramDetailServiceFactory()
        {
            var cosmosClientMock = new Mock<CosmosClient>();
            var configurationMock = new Mock<IConfiguration>();
            cosmosClientMock.Setup(c => c.GetContainer(It.IsAny<string>(), It.IsAny<string>())).Returns(ProgramDetailContainer.Object);
            ProgramDetailService = new ProgramDetailService(cosmosClientMock.Object, configurationMock.Object);
        }

        public ProgramDetailService ProgramDetailService { get; set; }
    }
}
