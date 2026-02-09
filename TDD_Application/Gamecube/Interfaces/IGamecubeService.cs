using TDD.Application.DTO;

namespace TDD.Application.Gamecube.Interfaces
{
    public interface IGamecubeService
    {
        public Task InsertGameAsync(string name);

        public Task<IEnumerable<GamecubeGame_DTO>> GetAllGamesAsync();

    }
}
