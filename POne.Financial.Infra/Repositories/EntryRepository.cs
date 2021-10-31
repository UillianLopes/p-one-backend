using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;

namespace POne.Financial.Infra.Repositories
{
    public class EntryRepository : Repository<POneFinancialDbContext, Entry>, IEntryRepository
    {
        public EntryRepository(POneFinancialDbContext dbContext) : base(dbContext)
        {
        }
    }
}
