using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnallyzerAPI.Controllers;
using AnallyzerAPI.DTO;
using AnallyzerAPI.Models;
using AnallyzerAPI.Services;
using Xunit;

namespace AnallyzerAPI.Tests
{
    public class CampainsControllerTests
    {
        private readonly Mock<ICampaignService> _mockCampaignService;
        private readonly CampainsController _controller;

        public CampainsControllerTests()
        {
            _mockCampaignService = new Mock<ICampaignService>();
            _controller = new CampainsController(_mockCampaignService.Object);
        }

        [Fact]
        public async Task GetAllCampains_ReturnsOkResult_WithListOfCampains()
        {
            // Arrange
            var campains = new List<Campain>
            {
                new Campain { ID = 1, Name = "Campanha 1", Description = "Descrição 1", Company = "Empresa 1", StartDate = DateTime.UtcNow, ForecastDate = DateTime.UtcNow, Status = "Ativa", RegistrationDate = DateTime.UtcNow },
                new Campain { ID = 2, Name = "Campanha 2", Description = "Descrição 2", Company = "Empresa 2", StartDate = DateTime.UtcNow, ForecastDate = DateTime.UtcNow, Status = "Ativa", RegistrationDate = DateTime.UtcNow }
            };

            _mockCampaignService.Setup(service => service.GetAllCampaignsAsync())
                .ReturnsAsync(campains);

            // Act
            var result = await _controller.GetAllCampains();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnCampains = Assert.IsType<List<Campain>>(okResult.Value);
            Assert.Equal(2, returnCampains.Count);
        }

        [Fact]
        public async Task GetCampain_ReturnsNotFound_WhenCampainDoesNotExist()
        {
            // Arrange
            var id = 1;
            _mockCampaignService.Setup(service => service.GetCampaignByIdAsync(id))
                .ReturnsAsync((Campain)null);

            // Act
            var result = await _controller.GetCampain(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostCampain_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var campainDto = new CampainDTO
            {
                Name = "Campanha 1",
                Description = "Descrição 1",
                Company = "Empresa 1",
                StartDate = DateTime.UtcNow,
                ForecastDate = DateTime.UtcNow
            };

            var createdCampain = new Campain
            {
                ID = 1,
                Name = campainDto.Name,
                Description = campainDto.Description,
                Company = campainDto.Company,
                StartDate = campainDto.StartDate,
                ForecastDate = campainDto.ForecastDate,
                RegistrationDate = DateTime.UtcNow
            };

            _mockCampaignService.Setup(service => service.CreateCampaignAsync(It.IsAny<Campain>()))
                .ReturnsAsync(createdCampain);

            // Act
            var result = await _controller.PostCampain(campainDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnCampain = Assert.IsType<Campain>(createdAtActionResult.Value);
            Assert.Equal(createdCampain.ID, returnCampain.ID);
        }

        [Fact]
        public async Task PutCampain_ReturnsNoContent_WhenUpdateIsSuccessful()
        {
            // Arrange
            var id = 1;
            var updateDto = new UpdateCampainDTO
            {
                Name = "Updated Name"
            };

            var existingCampain = new Campain
            {
                ID = id,
                Name = "Original Name",
                Description = "Descrição",
                Company = "Empresa",
                StartDate = DateTime.UtcNow,
                ForecastDate = DateTime.UtcNow,
                Status = "Ativa",
                RegistrationDate = DateTime.UtcNow
            };

            _mockCampaignService.Setup(service => service.GetCampaignByIdAsync(id))
                .ReturnsAsync(existingCampain);

            _mockCampaignService.Setup(service => service.UpdateCampaignAsync(id, It.IsAny<Campain>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.PutCampain(id, updateDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteCampain_ReturnsNotFound_WhenCampainDoesNotExist()
        {
            // Arrange
            var id = 1;
            _mockCampaignService.Setup(service => service.DeleteCampaignAsync(id))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteCampain(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
