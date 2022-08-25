using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Enums;
using POne.Core.Models;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.Categories;
using POne.Financial.Domain.Queries.Inputs.SubCategories;
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

        public Task<List<OptionModel>> GetAllAsOptionsAsync(GetAllCategoriesAsOptions filter, CancellationToken cancellationToken)
        {
            var query = _dbContext
                .Categories
                .Where(category => (
                    (!_authenticatedUser.IsStandalone && category.AccountId != null && category.AccountId == _authenticatedUser.AccountId) ||
                    (_authenticatedUser.IsStandalone && category.UserId != null && category.UserId == _authenticatedUser.Id)
                ));

            if (filter.Type is EntryOperation type)
                query = _dbContext
                    .Categories
                    .Where(category => category.Type == type);

            return query
                .OrderBy(c => c.Name)
                .Select(c => new OptionModel
                {
                    Title = c.Name,
                    Id = c.Id,
                    Color = c.Color
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }


        public Task<List<CategoryOuput>> GetAllAsync(GetAllCategories filter, CancellationToken cancellationToken)
        {
            var query = _dbContext
                .Categories
                .Where(category => (
                    (!_authenticatedUser.IsStandalone && category.AccountId != null && category.AccountId == _authenticatedUser.AccountId) ||
                    (_authenticatedUser.IsStandalone && category.UserId != null && category.UserId == _authenticatedUser.Id)
                ));

            if (filter.Type is EntryOperation type)
                query = query.Where(category => category.Type == type);

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
