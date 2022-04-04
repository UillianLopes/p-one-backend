using Microsoft.EntityFrameworkCore;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.Banks;
using POne.Financial.Domain.Queries.Outputs.Banks;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Infra.Repositories
{
    public class BankRepository : Repository<POneFinancialDbContext, Bank>, IBankRepository
    {
        public BankRepository(POneFinancialDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<BankOutput>> GetAllAsync(GetAllBanks request, CancellationToken cancellationToken) => _dbContext
            .Banks
            .OrderBy(b => b.Name)
            .Select(b => new BankOutput
            {
                Name = b.Name,
                Code = b.Code,
                Id = b.Id
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
