using TDD.Data.Interfaces;

namespace TDD.Data.Requests.Gamecube
{
    public class DeleteGameRequest : IDataExecute
    {
        private readonly string _name;

        public DeleteGameRequest(string name) => _name = name;

        public string GetSql() =>
            @"DELETE FROM dbo.GamecubeGames ('Name')
              VALUES (@Name);";

        public object GetParameters() =>
            new
            {
                Name = _name
            };
    }
}
