using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Domain.Queries.Outputs.SubCategories;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;
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

        public Task<List<SubCategoryOutput>> GetAllAsync(CancellationToken cancellationToken) => _dbContext
            .SubCategories
            .Where(c => c.AccountId == _authenticatedUser.AccountId)
            .OrderBy(c => c.Name)
            .Select(c => new SubCategoryOutput
            {
                Name = c.Name,
                Description = c.Description,
                Id = c.Id
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
