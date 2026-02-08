using TDD.Api.Controllers;

namespace TDD.Tests.DataRequestTests.Gamecube
{
    public class ReturnTests
    {
        [Fact]
        public async Task ReturnAllGames_ShouldReturnSuccessfully()
        {
            var insertRequest = await GamecubeController.InsertGame("Super Monkey Ball");
            var getRequest = await GamecubeController.GetAllGames();
            return getRequest;
        }
    }
}
