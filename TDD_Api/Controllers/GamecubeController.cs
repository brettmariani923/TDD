using TDD.Application.Gamecube.Interfaces;

namespace TDD.Api.Controllers
{
    public class GamecubeController
    {
        private readonly IGamecubeService _gamecube;
        public GamecubeController(IGamecubeService gamecube) => _gamecube = gamecube;

        public async Task InsertGame(string name)
        {
            var request = await _gamecube.InsertGameAsync(name);
        }
    }
}
