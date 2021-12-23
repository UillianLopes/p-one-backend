using POne.Core.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Domain.Queries.Inputs.SubCategories;
using POne.Financial.Domain.Queries.Outputs.SubCategories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        Task<List<SubCategoryOutput>> GetAllAsync(GetAllSubCategories filter, CancellationToken cancellationToken);
    }
}
