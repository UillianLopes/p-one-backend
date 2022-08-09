using Microsoft.EntityFrameworkCore;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using POne.Identity.Infra.Connections;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Infra.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly POneIdentityDbContext _dbContext;

        public RoleRepository(POneIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Role> FindByKeyAsync(string key, CancellationToken cancellationToken) => _dbContext
            .Roles
            .FirstOrDefaultAsync(r => r.Key == key, cancellationToken);
    }
}
