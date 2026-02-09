using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDD.Api.Controllers;
using TDD.Application.DTO;
using TDD.Application.Gamecube.Interfaces;

namespace TDD.Tests.ControllerTests
{
    public class GamecubeTests
    {
        [Fact]
        public async Task ReturnAllGames_ShouldReturnOk()
        {
            // Arrange
            var expectedGames = new List<GamecubeGame_DTO>
            {
                new GamecubeGame_DTO { Name = "Metroid Prime" },
                new GamecubeGame_DTO { Name = "Animal Crossing"}
            };

            var mockService = new Mock<IGamecubeService>();
            mockService.Setup(s => s.GetAllGamesAsync())
                       .ReturnsAsync(expectedGames);

            var controller = new GamecubeController(mockService.Object);

            // Act
            var result = await controller.GetAllGames();

            // Assert: status code + service called
            result.Result.Should().BeOfType<OkObjectResult>();
            mockService.Verify(s => s.GetAllGamesAsync(), Times.Once);
        }

        [Fact]
        public async Task InsertGame_ShouldReturnOk()
        {
            //Arrange
            var expectedGame = "Luigi's Mansion";

            var mockService = new Mock<IGamecubeService>();
            mockService.Setup(s => s.InsertGameAsync(expectedGame))
                       .Returns(Task.CompletedTask);

            var controller = new GamecubeController(mockService.Object);

            //Act
            var result = await controller.InsertGame(expectedGame);

            //Assert
            result.Should().BeOfType<OkResult>();
            mockService.Verify(s => s.InsertGameAsync(expectedGame), Times.Once);
        }

        [Fact]
        public async Task ReturnAllGames_NoGamesAdded_ShouldReturnMessage()
        {
            // Arrange
            var mockService = new Mock<IGamecubeService>();
            mockService.Setup(s => s.GetAllGamesAsync())
                       .ReturnsAsync(new List<GamecubeGame_DTO>());

            var controller = new GamecubeController(mockService.Object);

            // Act
            var result = await controller.GetAllGames();

            // Assert
            var ok = result.Result as OkObjectResult;
            ok.Should().NotBeNull();
            ok!.Value.Should().Be("No games added!");
        }
    }
}

