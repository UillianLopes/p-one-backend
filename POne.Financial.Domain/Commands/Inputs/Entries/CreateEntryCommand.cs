using POne.Core.CQRS;
using POne.Core.Enums;
using System;


namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class CreateEntryCommand : ICommand
    {
        public EntryRecurrence Recurrence { get; set; }
        public int RecurrenceTimes { get; set; }
        public int? RecurrenceDays { get; set; }
        public DateTime? DueDate { get; set; }
        public EntryType Type { get; private set; }
        public decimal Value { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public virtual Guid CategoryId { get; private set; }
        public virtual Guid SubCategoryId { get; private set; }
    }
}
