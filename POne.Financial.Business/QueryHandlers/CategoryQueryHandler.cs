using POne.Core.CQRS;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Queries.Inputs.Categories;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.QueryHandlers
{
    public class CategoryQueryHandler : IQueryHandler<GetAllCategories>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IQueryOutput> Handle(GetAllCategories query, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync(query, cancellationToken);

            return QueryOutput.Ok(categories);
        }
    }
}
