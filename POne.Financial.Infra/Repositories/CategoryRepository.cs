using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Enums;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.Categories;
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

        public Task<List<CategoryOuput>> GetAllAsync(GetAllCategories filter, CancellationToken cancellationToken)
        {
            var query = _dbContext
                .Categories
                .Where(c => c.UserId == _authenticatedUser.Id);

            if (filter.Type is EntryType type)
                query = query.Where(c => c.Type == type);

            return query
                .OrderBy(c => c.Name)
                .Select(c => new CategoryOuput
                {
                    Name = c.Name,
                    Description = c.Description,
                    Id = c.Id,
                    Type = c.Type,
                    Color = c.Color
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
