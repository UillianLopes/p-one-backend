using POne.Core.Enums;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class CreateRecurrentEntryCommand : CreateEntryCommand
    {
        public DateTime Begin { get; set; }
        public DateTime? End { get; set; }
        public EntryRecurrence Recurrence { get; set; }
        public int? DayOfMonth { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
    }
}
