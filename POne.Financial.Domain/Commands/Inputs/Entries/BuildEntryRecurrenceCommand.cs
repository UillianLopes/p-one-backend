using POne.Core.CQRS;
using POne.Core.Enums;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class CreatEntryInstallments : ICommand
    {
        public EntryRecurrence Recurrence { get; set; }
        public EntryValueDistribuition ValueDistribuition { get; set; }
        public int Installments { get; set; }
        public int Day { get; set; }
        public int IntervalInDays { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
    }
}
