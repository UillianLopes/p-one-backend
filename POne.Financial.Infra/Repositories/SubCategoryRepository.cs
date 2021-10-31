using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;

namespace POne.Financial.Infra.Repositories
{
    public class SubCategoryRepository : Repository<POneFinancialDbContext, SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(POneFinancialDbContext dbContext) : base(dbContext)
        {
        }
    }
}
