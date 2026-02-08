using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Data.Interfaces
{
    public interface IDataAccess
    {
        public Task<int> ExecuteAsync(IDataExecute request);

        public Task<TResponse?> FetchAsync<TResponse>(IDataFetch<TResponse> request);

        public Task<IEnumerable<TResponse>> FetchListAsync<TResponse>(IDataFetchList<TResponse> request);
    }
}
