using POne.Core.CQRS;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Queries.Inputs.SubCategories;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.QueryHandlers
{
    public class SubCategoryQueryHandler : IQueryHandler<GetAllSubCategories>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryQueryHandler(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<IQueryOutput> Handle(GetAllSubCategories query, CancellationToken cancellationToken)
        {
            var subCategories = await _subCategoryRepository.GetAllAsync(query, cancellationToken);

            return QueryOutput.Ok(subCategories);
        }
    }
}
