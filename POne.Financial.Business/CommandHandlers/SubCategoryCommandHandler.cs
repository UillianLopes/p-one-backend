using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Financial.Domain.Commands.Inputs.SubCategories;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Domain.Queries.Outputs.Categories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.CommandHandlers
{
    public class CategoryCommandHandler : ICommandHandler<CreateSubCategoryCommand>,
        ICommandHandler<UpdateSubCategoryCommand>,
        ICommandHandler<DeleteSubCategoryCommand>,
        ICommandHandler<DeleteSubCategoriesCommand>
    {
        private readonly ISubCategoryRepository _subCategoryRepsitory;
        private readonly ICategoryRepository _categoryRepsitory;
        private readonly IAuthenticatedUser _authenticatedUser;

        public CategoryCommandHandler(ISubCategoryRepository subCategoryRepsitory, IAuthenticatedUser authenticatedUser, ICategoryRepository categoryRepsitory)
        {
            _subCategoryRepsitory = subCategoryRepsitory;
            _authenticatedUser = authenticatedUser;
            _categoryRepsitory = categoryRepsitory;
        }

        public async Task<ICommandOuput> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {

            if (await _categoryRepsitory.FindByIdAync(request.CategoryId, cancellationToken) is not Category category)
                return CommandOutput.NotFound("@PONE.MESSAGES.CATEGORY_NOT_FOUND");

            var subCategory = new SubCategory(category, request.Name, request.Description);

            await _subCategoryRepsitory.CreateAync(subCategory, cancellationToken);

            return CommandOutput.Created($"/category/{subCategory.Id}", new
            {
                subCategory.Id,
                subCategory.Name,
                subCategory.Description,
                Category = new CategoryOuput
                {
                    Name = category.Name,
                    Id = category.Id,
                    Description = category.Description
                }
            }, "@PONE.MESSAGES.SUB_CATEGORY_CREATED");
        }

        public async Task<ICommandOuput> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _categoryRepsitory.FindByIdAync(request.CategoryId, cancellationToken) is not Category category)
                return CommandOutput.NotFound("@PONE.MESSAGES.CATEGORY_NOT_FOUND");

            if (await _subCategoryRepsitory.FindByIdAync(request.Id, cancellationToken) is not SubCategory subCategory)
                return CommandOutput.NotFound("@PONE.MESSAGES.SUB_CATEGORY_NOT_FOUND");

            subCategory.Update(request.Name, request.Description, category);

            return CommandOutput.Ok(new
            {
                subCategory.Id,
                subCategory.Name,
                subCategory.Description,
                Category = new CategoryOuput
                {
                    Name = category.Name,
                    Id = category.Id,
                    Description = category.Description
                }
            }, "@PONE.MESSAGES.SUB_CATEGORY_UPDATED");
        }

        public async Task<ICommandOuput> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _subCategoryRepsitory.FindByIdAync(request.Id, cancellationToken) is not SubCategory subCategory)
                return CommandOutput.NotFound("@PONE.MESSAGES.SUB_CATEGORY_NOT_FOUND");

            _subCategoryRepsitory.Delete(subCategory);

            return CommandOutput.Ok("@PONE.MESSAGES.SUB_CATEGORY_DELETED");
        }

        public async Task<ICommandOuput> Handle(DeleteSubCategoriesCommand request, CancellationToken cancellationToken)
        {
            if (await _subCategoryRepsitory.FindByIdsAync(request.Ids, cancellationToken) is not List<SubCategory> subCategories || subCategories.Count == 0)
                return CommandOutput.NotFound("@PONE.MESSAGES.SUB_CATEGORIES_NOT_FOUND");

            _subCategoryRepsitory.DeleteRange(subCategories.ToArray());

            return CommandOutput.Ok("@PONE.MESSAGES.SUB_CATEGORIES_DELETED");
        }
    }
}
