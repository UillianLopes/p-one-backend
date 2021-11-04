using POne.Core.CQRS;

namespace POne.Financial.Domain.Commands.Inputs.Categories
{
    public class CreateCategoryCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
