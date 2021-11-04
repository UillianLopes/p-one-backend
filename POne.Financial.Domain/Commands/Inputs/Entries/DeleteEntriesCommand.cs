using System;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class DeleteEntriesCommand
    {
        public Guid[] Ids { get; set; }
    }
}
