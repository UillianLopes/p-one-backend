using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Domain.Queries.Outputs.Categories;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Infra.Repositories
{
    public class CategoryRepository : Repository<POneFinancialDbContext, Category>, ICategoryRepository
    {
        private readonly IAuthenticatedUser _authenticatedUser;

        public CategoryRepository(IAuthenticatedUser authenticatedUser, POneFinancialDbContext dbContext) : base(dbContext) => _authenticatedUser = authenticatedUser;

        public Task<List<CategoryOuput>> GetAllAsync(CancellationToken cancellationToken) => _dbContext
            .Categories
            .Where(c => c.AccountId == _authenticatedUser.AccountId)
            .OrderBy(c => c.Name)
            .Select(c => new CategoryOuput
            {
                Name = c.Name,
                Description = c.Description,
                Id = c.Id,
                Type = c.Type,
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
