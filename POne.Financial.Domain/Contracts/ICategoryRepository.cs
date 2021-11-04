using POne.Core.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Domain.Queries.Outputs.Categories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<CategoryOuput>> GetAllAsync(CancellationToken cancellationToken);
    }
}
