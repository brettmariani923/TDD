using TDD.Data.Rows;

namespace TDD.Application.Gamecube.Interfaces
{
    public interface IGamecubeService
    {
        public Task InsertGameAsync(GamecubeGame_Row name);

        public Task<IEnumerable<GamecubeGame_Row>> GetAllGamesAsync();

    }
}
