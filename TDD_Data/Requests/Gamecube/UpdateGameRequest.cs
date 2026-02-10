using TDD.Data.Interfaces;

namespace TDD.Data.Requests.Gamecube
{
    public class UpdateGameRequest : IDataExecute
    {
        private readonly string _name;
        private readonly string _updated;

        public UpdateGameRequest(string name, string updated)
        {
            _name = name;
            _updated = updated;
        }

        public string GetSql() =>
            @"UPDATE dbo.GamecubeGames
              SET Name = @Updated
              WHERE Name = @Name;";

        public object GetParameters() =>
            new
            {
                Name = _name,
                Updated = _updated
            };
    }
}
