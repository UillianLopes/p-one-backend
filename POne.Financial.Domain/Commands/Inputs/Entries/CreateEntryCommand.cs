using POne.Core.CQRS;
using POne.Core.Enums;
using POne.Core.ValueObjects;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{

    public class CreateEntryItem
    {
        public int Index { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
        public string BarCode { get; set; }
    }

    public class CreateEntryCommand : ICommand
    {
        public EntryOperation Operation { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public ICollection<CreateEntryItem> Installments { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
        public string BarCode { get; set; }
        public string Currency { get; set; }

        public MonthReference RecurrenceEnd { get; set; }
        public EntryRecurrence? Recurrence { get; set; }
        public int? RecurrenceDay { get; set; }
    }
}
