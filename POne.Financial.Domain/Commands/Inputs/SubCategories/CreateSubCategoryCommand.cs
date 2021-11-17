using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.SubCategories
{
    public class CreateSubCategoryCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
