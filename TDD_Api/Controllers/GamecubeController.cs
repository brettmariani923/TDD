using TDD.Application.Gamecube.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TDD.Api.DTO;

namespace TDD.Api.Controllers
{
    public class GamecubeController
    {
        private readonly IGamecubeService _gamecube;
        public GamecubeController(IGamecubeService gamecube) => _gamecube = gamecube;

        
        public async Task InsertGame(string name)
        {
            var request = await _gamecube.InsertGameAsync(name);
            return request;
        }

        public async Task <ActionResult<IEnumerable<GamecubeGame_DTO>>> GetAllGames()
        {
            var request = await _gamecube.GetAllGamesAsync();
            return request;
        }
    }
}
