using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Categories
{
    public class DeleteCategoriesCommand : ICommand
    {
        public Guid[] Ids { get; set; }
    }
}
