using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.SubCategories
{
    public class UpdateSubCategoryCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
