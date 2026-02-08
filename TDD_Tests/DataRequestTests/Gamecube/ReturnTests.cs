using TDD.Api.Controllers.GamecubeController;
using Xunit;

namespace TDD.Tests.DataRequestTests.Gamecube
{
    public class ReturnTests
    {
        [Fact]
        public async Task ReturnAllGames_ShouldReturnSuccessfully()
        {
            var insert = "Super Monkey Ball";
            await InsertGame(insert);

            var games = await GetAllGames();

            games.Should().Contain(i => i.Name == insertedName);
        }
    }
}
