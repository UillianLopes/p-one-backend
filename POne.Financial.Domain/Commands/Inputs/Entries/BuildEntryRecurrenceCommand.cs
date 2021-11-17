using POne.Core.CQRS;
using POne.Core.Enums;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class BuildEntryRecurrenceCommand : ICommand
    {
        public EntryRecurrence Recurrence { get; set; }
        public int Times { get; set; }
        public int Day { get; set; }
        public int IntervalInDays { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
        public EntryValueDistribuition ValueDistribuition { get; set; }
    }
}
