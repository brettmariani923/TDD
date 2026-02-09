using Microsoft.AspNetCore.Mvc;
using TDD.Application.DTO;
using TDD.Application.Gamecube.Interfaces;

namespace TDD.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamecubeController : ControllerBase
    {
        private readonly IGamecubeService _gamecube;
        public GamecubeController(IGamecubeService gamecube) => _gamecube = gamecube;

        [HttpPost]
        public async Task<ActionResult> InsertGame([FromQuery] string name)
        {
            await _gamecube.InsertGameAsync(name);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamecubeGame_DTO>>> GetAllGames()
        {
            string answer = "No games added!";

            var games = await _gamecube.GetAllGamesAsync();

            if (games == null || !games.Any())
                return Ok(answer);

            return Ok(games);
        }

    }
}
