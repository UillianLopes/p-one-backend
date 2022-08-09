using POne.Core.CQRS;
using POne.Core.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Core.Contracts
{
    public interface IAsOptionsRepository<T> where T : class, IQuery
    {
        Task<List<OptionModel>> GetAllAsOptionsAsync(T query, CancellationToken cancellationToken);
    }
}
