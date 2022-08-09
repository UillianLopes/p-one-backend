using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Models;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.SubCategories;
using POne.Financial.Domain.Queries.Outputs.Categories;
using POne.Financial.Domain.Queries.Outputs.SubCategories;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Infra.Repositories
{
    public class SubCategoryRepository : Repository<POneFinancialDbContext, SubCategory>, ISubCategoryRepository
    {
        private readonly IAuthenticatedUser _authenticatedUser;

        public SubCategoryRepository(IAuthenticatedUser authenticatedUser, POneFinancialDbContext dbContext) : base(dbContext) => _authenticatedUser = authenticatedUser;

        public Task<List<OptionModel>> GetAllAsOptionsAsync(GetAllSubCategoriesAsOptions filter, CancellationToken cancellationToken)
        {
            var query = _dbContext
               .SubCategories
               .Where(subCategory =>
                    (!_authenticatedUser.IsStandalone && subCategory.Category.AccountId != null && subCategory.Category.AccountId == _authenticatedUser.AccountId) ||
                    (_authenticatedUser.IsStandalone && subCategory.Category.UserId != null && subCategory.Category.UserId == _authenticatedUser.Id));
            
            if (filter.CategoryId is Guid categoryId)
                query = query.Where(subCategory => subCategory.Category.Id == categoryId);

            return query
                .OrderBy(c => c.Name)
                .Select(c => new OptionModel
                {
                    Title = c.Name,
                    Id = c.Id,
                    Color = c.Color,
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public Task<List<SubCategoryOutput>> GetAllAsync(GetAllSubCategories filter, CancellationToken cancellationToken)
        {
            var query = _dbContext
               .SubCategories
               .Where(subCategory => (!_authenticatedUser.IsStandalone && subCategory.Category.AccountId != null && subCategory.Category.AccountId == _authenticatedUser.AccountId) ||
                    (_authenticatedUser.IsStandalone && subCategory.Category.UserId != null && subCategory.Category.UserId == _authenticatedUser.Id));

            if (filter.CategoryId is Guid categoryId && categoryId != Guid.Empty)
                query = query.Where(c => c.Category.Id == categoryId);


            return query
                .OrderBy(c => c.Name)
                .Select(c => new SubCategoryOutput
                {
                    Name = c.Name,
                    Description = c.Description,
                    Id = c.Id,
                    Color = c.Color,
                    Category = new CategoryOuput
                    {
                        Name = c.Category.Name,
                        Id = c.Category.Id,
                        Description = c.Category.Description,
                        Type = c.Category.Type,
                        Color = c.Category.Color
                    }
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
