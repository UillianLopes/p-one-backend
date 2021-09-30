using POne.Domain.Entities;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Infra.Connections;
using POne.Infra.Repositories;

namespace POne.Identity.Infra.Repositories
{
    public class AccountRepository : Repository<POneIdentityDbContext, Account>, IAccountRepository
    {
        public AccountRepository(POneIdentityDbContext dbContext) : base(dbContext)
        {
        }
    }
}
