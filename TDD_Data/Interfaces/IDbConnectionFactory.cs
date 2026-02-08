using System.Data;

namespace TDD.Data.Interfaces
{
    public interface IDbConnectionFactory
    {
        public IDbConnection NewConnection();
    }
}
