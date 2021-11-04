using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.SubCategories
{
    public class DeleteSubCategoryCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
