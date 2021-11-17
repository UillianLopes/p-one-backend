using POne.Core.CQRS;
using POne.Core.Enums;

namespace POne.Financial.Domain.Commands.Inputs.Categories
{
    public class CreateCategoryCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EntryType Type { get; set; }
    }
}
