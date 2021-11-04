using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Financial.Domain.Commands.Inputs.SubCategories;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
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
        private readonly IAuthenticatedUser _authenticatedUser;

        public CategoryCommandHandler(ISubCategoryRepository subCategoryRepsitory, IAuthenticatedUser authenticatedUser)
        {
            _subCategoryRepsitory = subCategoryRepsitory;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<ICommandOuput> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var subCategory = new SubCategory(request.Name, request.Description, _authenticatedUser.Id, _authenticatedUser.AccountId);

            await _subCategoryRepsitory.CreateAync(subCategory, cancellationToken);

            return CommandOutput.Created($"/category/{subCategory.Id}", new
            {
                subCategory.Id,
                subCategory.Name,
                subCategory.Description
            }, "@PONE.MESSAGES.SUB_CATEGORY_CREATED");
        }

        public async Task<ICommandOuput> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _subCategoryRepsitory.FindByIdAync(request.Id, cancellationToken) is not SubCategory subCategory)
                return CommandOutput.NotFound("@PONE.MESSAGES.SUB_CATEGORY_NOT_FOUND");

            subCategory.Update(request.Name, request.Description);

            return CommandOutput.Ok("@PONE.MESSAGES.SUB_CATEGORY_UPDATED");
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
