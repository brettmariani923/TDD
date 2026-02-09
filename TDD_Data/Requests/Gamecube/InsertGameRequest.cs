using TDD.Data.Interfaces;

namespace TDD.Data.Requests.Gamecube
{
    public class InsertGameRequest : IDataExecute
    {
        private readonly string _name;

        public InsertGameRequest(string name) => _name = name;

        public string GetSql() =>
            @"INSERT INTO dbo.GamecubeGames (Name)
              VALUES (@Name);";

        public object GetParameters() =>
            new
            {
                Name = _name
            };
    }
}
