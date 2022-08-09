using POne.Core.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.Categories;
using POne.Financial.Domain.Queries.Outputs.Categories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts
{
    public interface ICategoryRepository : IRepository<Category>, IAsOptionsRepository<GetAllCategoriesAsOptions>
    {
        Task<List<CategoryOuput>> GetAllAsync(GetAllCategories query, CancellationToken cancellationToken);
    }
}
