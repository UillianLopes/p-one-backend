using POne.Core.CQRS;
using POne.Core.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Core.Contracts
{

    public interface IAsOptionsRepository<T, R> where T : class, IQuery
    {
        Task<List<R>> GetAllAsOptionsAsync(T query, CancellationToken cancellationToken);
    }

    public interface IAsOptionsRepository<T> : IAsOptionsRepository<T, OptionModel> where T : class, IQuery
    {
    }
}
