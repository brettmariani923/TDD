using TDD.Data.Interfaces;
using TDD.Data.Rows;

namespace TDD.Data.Requests.Gamecube
{
    public class InsertGameRequest : IDataExecute
    {
        private readonly GamecubeGame_Row _name;

        public InsertGameRequest(GamecubeGame_Row name) => _name = name;

        public string GetSql() =>
            @"INSERT INTO dbo.GamecubeGames (Name) " +
             "VALUES (@Name);";

        public object GetParameters() =>
            new
            {
                _name.Name
            };
    }
}
