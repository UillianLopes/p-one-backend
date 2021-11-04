using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class DeleteEntriesCommand : ICommand
    {
        public Guid[] Ids { get; set; }
    }
}
