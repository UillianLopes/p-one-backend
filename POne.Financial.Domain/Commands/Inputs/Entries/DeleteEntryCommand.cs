using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class DeleteEntryCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
