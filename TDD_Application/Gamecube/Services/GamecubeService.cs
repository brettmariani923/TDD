using TDD.Data.Gamecube.Interfaces;

namespace TDD.Application.Gamecube.Services
{
    public class GamecubeService
    {
        private readonly IDataAccess _data;
        public GamecubeService(IDataAccess data) => _data = data;

        public async Task InsertGameAsync(string name)
        {
            var request = await _data.InsertGameRequest(name);
        }
    }
}
