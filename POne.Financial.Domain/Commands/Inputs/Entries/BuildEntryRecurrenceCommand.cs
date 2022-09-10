using POne.Core.CQRS;
using POne.Core.Enums;
using POne.Core.ValueObjects;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class CreatEntryInstallments : ICommand
    {
        public MonthReference Begin { get; set; }
        public EntryRecurrence Recurrence { get; set; }
        public EntryValueDistribuition ValueDistribuition { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public int Installments { get; set; }
        public int Day { get; set; }
        public decimal Value { get; set; }
    }
}
