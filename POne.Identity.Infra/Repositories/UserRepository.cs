using Microsoft.EntityFrameworkCore;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using POne.Identity.Infra.Connections;
using POne.Infra.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Infra.Repositories
{
    public class UserRepository : Repository<POneIdentityDbContext, User>, IUserRepository
    {
        public UserRepository(POneIdentityDbContext dbContext) : base(dbContext) { }

        public Task<User> FindByEmail(string email, CancellationToken cancellationToken) => _dbContext
            .Set<User>()
            .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);

        public Task<UserSettings> GetUserSettingsAsync(Guid id, CancellationToken cancellationToken) => _dbContext
            .Set<User>()
            .Where(u => u.Id == id)
            .Select(u => u.Settings)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}
