using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Categories
{
    public class DeleteCategoryCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
