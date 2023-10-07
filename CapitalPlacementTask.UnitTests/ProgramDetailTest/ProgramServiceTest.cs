using CapitalPlacementTask.Application.DTOs.ProgramDTOs;
using CapitalPlacementTask.Domain.Entities;
using Microsoft.Azure.Cosmos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementTask.UnitTests.ProgramDetailTest
{
    public class ProgramServiceTest
    {
        private readonly ProgramDetailServiceFactory _fac;

        public ProgramServiceTest()
        {
            _fac = new ProgramDetailServiceFactory();            
        }

        [Fact]
        private async Task CreateProgramDetail_ShouldWork()
        {
            //Arrange

            //Act

            var result = await _fac.ProgramDetailService.CreateProgramDetail(new CreateProgramDTO());

            //Assert
            Assert.False(result.HasError);
        }

        [Fact]
        private async Task DeleteProgramDetail_ShouldWork() 
        {
            //Arrange
            var programDetail = new ProgramDetail
            {
                Id = Guid.Parse("0f4bd353-41a6-4f09-b1c6-380d8c84cd62")
            };

            //var responseMock = new Mock<ItemResponse<ProgramDetail>>(HttpStatusCode.OK, null, programDetail, null, null);
            var responseMock2 = new Mock<ItemResponse<ProgramDetail>>();
            responseMock2.Setup(x => x.Resource).Returns(programDetail); //expectedItem is of VehicleInfo type


            _fac.ProgramDetailContainer.Setup(c => c.ReadItemAsync<ProgramDetail>(programDetail.Id.ToString(), new PartitionKey(programDetail.Id.ToString()), null, default))
                .ReturnsAsync(responseMock2.Object);

            
            //Act

           //var result = await _fac.ProgramDetailService.DeleteProgramDetail(It.IsAny<Guid>());
            var result = await _fac.ProgramDetailService.DeleteProgramDetail(programDetail.Id);

            //Assert
            Assert.False(result.HasError);
        }

        [Fact]
        private async Task DeleteProgramDetail_ShouldReturnError_WhenProgramDetail_DoesnotExist()
        {
            //Arrange
            
            var responseMock = new Mock<ItemResponse<ProgramDetail>>();


            _fac.ProgramDetailContainer.Setup(c => c.ReadItemAsync<ProgramDetail>(It.IsAny<string>(), It.IsAny<PartitionKey>(), null, default))
            .ReturnsAsync(responseMock.Object);


            //Act

            var result = await _fac.ProgramDetailService.DeleteProgramDetail(It.IsAny<Guid>());

            //Assert
            Assert.True(result.HasError);
        }



        [Fact]
        private async Task UpdateProgramDetail_ShouldWork()
        {
            //Arrange

            var programDetail = new ProgramDetail
            {
                Id = Guid.Parse("0f4bd353-41a6-4f09-b1c6-380d8c84cd62")
            };

            //Act
            var responseMock2 = new Mock<ItemResponse<ProgramDetail>>();
            responseMock2.Setup(x => x.Resource).Returns(programDetail); 


            _fac.ProgramDetailContainer.Setup(c => c.ReadItemAsync<ProgramDetail>(programDetail.Id.ToString(), new PartitionKey(programDetail.Id.ToString()), null, default))
                .ReturnsAsync(responseMock2.Object);

            var result = await _fac.ProgramDetailService.UpdateProgramDetail(new UpdateProgramDetailDTO(), programDetail.Id);

            //Assert
            Assert.False(result.HasError);
        }


        [Fact]
        private async Task GetProgramDetail_ShouldWork()
        {
            //Arrange

            var programDetail = new ProgramDetail
            {
                Id = Guid.Parse("0f4bd353-41a6-4f09-b1c6-380d8c84cd62")
            };

            //Act
            var responseMock2 = new Mock<ItemResponse<ProgramDetail>>();
            responseMock2.Setup(x => x.Resource).Returns(programDetail);


            _fac.ProgramDetailContainer.Setup(c => c.ReadItemAsync<ProgramDetail>(programDetail.Id.ToString(), new PartitionKey(programDetail.Id.ToString()), null, default))
                .ReturnsAsync(responseMock2.Object);

            var result = await _fac.ProgramDetailService.GetProgramDetail(programDetail.Id);

            //Assert
            Assert.False(result.HasError);
        }
    }
}
