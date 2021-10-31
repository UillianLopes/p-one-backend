using POne.Core.CQRS;
using POne.Financial.Business.Commands.Inputs.Categories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.CommandHandlers
{
    public class CategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        public Task<ICommandOuput> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
