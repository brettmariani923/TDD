using TDD.Application.Gamecube.Services;

namespace TDD.Tests.DataRequestTests.Gamecube
{
    public class InsertTests
    {
        [Fact]
        public void AddGame_ShouldStoreGame()
        {
            var service = new GamecubeService();
            service.AddGame("Metroid Prime");

            service.GetAllGames()
                .Should()
                .Contain(g => g.Name == "Metroid Prime");
        }

    }
}
