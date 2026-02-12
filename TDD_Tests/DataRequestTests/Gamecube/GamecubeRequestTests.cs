using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using TDD.Application.Gamecube.Services;
using TDD.Data.Interfaces;
using TDD.Data.Requests.Gamecube;

namespace TDD.Tests.DataRequestTests.Gamecube
{
    public class GamecubeRequestTests
    {
        //Insert
        [Fact]
        public async Task InsertGameAsync_ShouldExecuteInsertRequest_WithCorrectSqlAndParameters()
        {
            // Arrange
            var data = new Mock<IDataAccess>();
            var service = new GamecubeService(data.Object);

            // Act
            await service.InsertGameAsync("Metroid Prime");

            // Assert
            data.Verify(d => d.ExecuteAsync(It.Is<IDataExecute>(req =>
                req.GetSql().Contains("INSERT INTO dbo.GamecubeGames") &&
                req.GetSql().Contains("VALUES (@Name)") &&
                HasNameParam(req.GetParameters(), "Metroid Prime")
            )), Times.Once);
        }

        private static bool HasNameParam(object parameters, string expectedName)
        {
            if (parameters is null) return false;

            var prop = parameters.GetType().GetProperty("Name");
            if (prop is null) return false;

            var value = prop.GetValue(parameters) as string;
            return value == expectedName;
        }
    }

}
