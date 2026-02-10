using TDD.Application.DTO;

namespace TDD.Application.Gamecube.Interfaces
{
    public interface IGamecubeService
    {
        public Task InsertGameAsync(string name);

        public Task<IEnumerable<GamecubeGame_DTO>> GetAllGamesAsync();

        public Task DeleteGameAsync(string name);

        public Task UpdateGameAsync(string name, string updated);


    }
}
