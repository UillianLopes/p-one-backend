using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Financial.Domain.Commands.Inputs.Categories;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.CommandHandlers
{
    public class SubCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>,
        ICommandHandler<UpdateCategoryCommand>,
        ICommandHandler<DeleteCategoryCommand>,
        ICommandHandler<DeleteCategoriesCommand>
    {
        private readonly ICategoryRepository _categoryRepsitory;
        private readonly IAuthenticatedUser _authenticatedUser;

        public SubCategoryCommandHandler(ICategoryRepository categoryRepsitory, IAuthenticatedUser authenticatedUser)
        {
            _categoryRepsitory = categoryRepsitory;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<ICommandOuput> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(
                _authenticatedUser.Id,
                _authenticatedUser.AccountId,
                request.Name,
                request.Description,
                request.Color,
                request.Type
             );

            await _categoryRepsitory.CreateAync(category, cancellationToken);

            return CommandOutput.Created($"/category/{category.Id}", new
            {
                category.Id,
                category.Name,
                category.Description,
                category.Type,
                category.Color
            }, "@PONE.MESSAGES.CATEGORY_CREATED");
        }

        public async Task<ICommandOuput> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _categoryRepsitory.FindByIdAync(request.Id, cancellationToken) is not Category category)
                return CommandOutput.NotFound("@PONE.MESSAGES.CATEGORY_NOT_FOUND");

            category.Update(request.Name, request.Description, request.Color, request.Type);

            return CommandOutput.Ok(new
            {
                category.Id,
                category.Name,
                category.Description,
                category.Type,
                category.Color
            }, "@PONE.MESSAGES.CATEGORY_UPDATED");
        }

        public async Task<ICommandOuput> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _categoryRepsitory.FindByIdAync(request.Id, cancellationToken) is not Category category)
                return CommandOutput.NotFound("@PONE.MESSAGES.CATEGORY_NOT_FOUND");

            _categoryRepsitory.Delete(category);

            return CommandOutput.Ok("@PONE.MESSAGES.CATEGORY_DELETED");
        }

        public async Task<ICommandOuput> Handle(DeleteCategoriesCommand request, CancellationToken cancellationToken)
        {
            if (await _categoryRepsitory.FindByIdsAync(request.Ids, cancellationToken) is not List<Category> categories || categories.Count == 0)
                return CommandOutput.NotFound("@PONE.MESSAGES.CATEGORIES_NOT_FOUND");

            _categoryRepsitory.DeleteRange(categories.ToArray());

            return CommandOutput.Ok("@PONE.MESSAGES.CATEGORIES_DELETED");
        }
    }
}
