using TDD.Data.Rows;
using TDD.Data.Interfaces;

namespace TDD.Data.Requests.Gamecube
{
    public class GetAllGamesRequest : IDataFetchList<GamecubeGame_Row>
    {
        public string GetSql() =>
            @"SELECT * FROM dbo.GamecubeGames;";

        public object? GetParameters() => null;
    
    }
}
