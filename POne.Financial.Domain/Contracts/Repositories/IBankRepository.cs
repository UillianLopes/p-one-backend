using POne.Core.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.Banks;
using POne.Financial.Domain.Queries.Outputs.Banks;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts
{
    public interface IBankRepository : IRepository<Bank>
    {
        Task<List<BankOutput>> GetAllAsync(GetAllBanks request, CancellationToken cancellationToken);
    }
}
