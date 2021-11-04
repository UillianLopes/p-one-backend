using POne.Core.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Domain.Queries.Outputs.Balances;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts
{
    public interface IBalanceRepository : IRepository<Balance>
    {
        Task<List<BalanceOutput>> GetAllAsync(CancellationToken cancellationToken);
    }
}
