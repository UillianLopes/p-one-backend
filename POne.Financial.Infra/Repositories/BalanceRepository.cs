using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Domain.Queries.Outputs.Balances;
using POne.Financial.Domain.Queries.Outputs.Banks;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Infra.Repositories
{
    public class BalanceRepository : Repository<POneFinancialDbContext, Balance>, IBalanceRepository
    {
        private readonly IAuthenticatedUser _authenticatedUser;

        public BalanceRepository(IAuthenticatedUser authenticatedUser, POneFinancialDbContext dbContext) : base(dbContext) => _authenticatedUser = authenticatedUser;

        public Task<List<BalanceOutput>> GetAllAsync(CancellationToken cancellationToken) => _dbContext
            .Balances
            .Where(c => c.UserId == _authenticatedUser.Id)
            .OrderBy(c => c.Name)
            .Select(c => new BalanceOutput
            {
                Id = c.Id,
                Name = c.Name,
                Value = c.Value,
                Agency = c.Agency,
                Bank = c.Bank != null ? new BankOutput { Id = c.Bank.Id, Name = c.Bank.Name, Code = c.Bank.Code } : null,
                Number = c.Number
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
