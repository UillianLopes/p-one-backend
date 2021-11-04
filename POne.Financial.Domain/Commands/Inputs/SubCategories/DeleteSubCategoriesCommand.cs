using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.SubCategories
{
    public class DeleteSubCategoriesCommand : ICommand
    {
        public Guid[] Ids { get; set; }
    }
}
