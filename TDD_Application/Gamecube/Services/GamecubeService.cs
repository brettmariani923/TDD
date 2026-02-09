using TDD.Data.Interfaces;
using TDD.Data.Requests.Gamecube;
using TDD.Data.Rows;
using TDD.Application.DTO;
using TDD.Application.Gamecube.Interfaces;

namespace TDD.Application.Gamecube.Services
{
    public class GamecubeService : IGamecubeService
    {
        private readonly IDataAccess _data;
        public GamecubeService(IDataAccess data) => _data = data;

        public async Task<int> InsertGameAsync(string name)
        {
            return await _data.ExecuteAsync(new InsertGameRequest(name));
        }

        public async Task<IEnumerable<GamecubeGame_DTO>> GetAllGamesAsync()
        {
            var request = new GetAllGamesRequest();
            var rows = await _data.FetchListAsync<GamecubeGame_Row>(request);

            return rows.Select(r => new GamecubeGame_DTO
            {
                Name = r.Name
            });
        }

    }
}
