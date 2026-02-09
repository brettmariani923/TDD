using TDD.Data.Interfaces;
using TDD.Data.Requests.Gamecube;
using TDD.Data.Rows;
using TDD.Application.Gamecube.Interfaces;

namespace TDD.Application.Gamecube.Services
{
    public class GamecubeService : IGamecubeService
    {
        private readonly IDataAccess _data;
        public GamecubeService(IDataAccess data) => _data = data;

        public async Task InsertGameAsync(string name)
        {
            await _data.ExecuteAsync(new InsertGameRequest(name));
        }

        public async Task<IEnumerable<GamecubeGame_Row>> GetAllGamesAsync()
        {
            var request = new GetAllGamesRequest();
            var games = await _data.FetchListAsync<GamecubeGame_Row>(request);
            return games;
        }
    }
}
