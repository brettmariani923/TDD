using FluentAssertions;
using Moq;
using TDD.Application.Gamecube.Services;
using TDD.Data.Interfaces;
using TDD.Data.Requests.Gamecube;
using TDD.Data.Rows;

public class GamecubeServiceTests
{
    //Insert Tests
    [Fact]
    public async Task InsertGameAsync_ShouldExecuteInsertRequest()
    {
        // Arrange
        var data = new Mock<IDataAccess>();

        data.Setup(d => d.ExecuteAsync(It.IsAny<InsertGameRequest>()))
            .ReturnsAsync(1);

        var service = new GamecubeService(data.Object);

        // Act
        await service.InsertGameAsync("Luigi's Mansion");

        // Assert
        data.Verify(d => d.ExecuteAsync(It.IsAny<InsertGameRequest>()), Times.Once);
        data.VerifyNoOtherCalls();
    }

    //Delete Tests
    [Fact]
    public async Task DeleteGameAsync_ShouldExecuteDeleteRequest()
    {
        var data = new Mock<IDataAccess>();
        data.Setup(d => d.ExecuteAsync(It.IsAny<DeleteGameRequest>()))
            .ReturnsAsync(1);

        var service = new GamecubeService(data.Object);

        await service.DeleteGameAsync("Animal Crossing");

        data.Verify(d => d.ExecuteAsync(It.IsAny<DeleteGameRequest>()), Times.Once);
        data.VerifyNoOtherCalls();
    }

    //Update Tests
    [Fact]
    public async Task UpdateGameAsync_ShouldExecuteUpdateRequest()
    {
        var data = new Mock<IDataAccess>();
        data.Setup(d => d.ExecuteAsync(It.IsAny<UpdateGameRequest>()))
            .ReturnsAsync(1);

        var service = new GamecubeService(data.Object);

        await service.UpdateGameAsync("Super Mario Sunshine", "Mario Sunshine");

        data.Verify(d => d.ExecuteAsync(It.IsAny<UpdateGameRequest>()), Times.Once);
        data.VerifyNoOtherCalls();
    }

    //Return Tests
    [Fact]
    public async Task GetAllGamesAsync_ShouldReturnDtosMappedFromRows()
    {
        // Arrange
        var rows = new List<GamecubeGame_Row>
        {
            new GamecubeGame_Row { Name = "Metroid Prime" },
            new GamecubeGame_Row { Name = "Pikmin" }
        };

        var data = new Mock<IDataAccess>();
        data.Setup(d => d.FetchListAsync<GamecubeGame_Row>(It.IsAny<GetAllGamesRequest>()))
            .ReturnsAsync(rows);

        var service = new GamecubeService(data.Object);

        // Act
        var result = (await service.GetAllGamesAsync()).ToList();

        // Assert
        result.Should().HaveCount(2);
        result.Select(r => r.Name).Should().ContainInOrder("Metroid Prime", "Pikmin");

        data.Verify(d => d.FetchListAsync<GamecubeGame_Row>(It.IsAny<GetAllGamesRequest>()), Times.Once);
        data.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task GetAllGamesAsync_WhenNoRows_ShouldReturnEmpty()
    {
        var data = new Mock<IDataAccess>();
        data.Setup(d => d.FetchListAsync<GamecubeGame_Row>(It.IsAny<GetAllGamesRequest>()))
            .ReturnsAsync(new List<GamecubeGame_Row>());

        var service = new GamecubeService(data.Object);

        var result = await service.GetAllGamesAsync();

        result.Should().NotBeNull();
        result.Should().BeEmpty();

        data.Verify(d => d.FetchListAsync<GamecubeGame_Row>(It.IsAny<GetAllGamesRequest>()), Times.Once);
        data.VerifyNoOtherCalls();
    }

}
