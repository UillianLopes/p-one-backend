using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;

namespace POne.Financial.Infra.Repositories
{
    public class BalanceRepository : Repository<POneFinancialDbContext, Balance>, IBalanceRepository
    {
        public BalanceRepository(POneFinancialDbContext dbContext) : base(dbContext)
        {
        }
    }
}
