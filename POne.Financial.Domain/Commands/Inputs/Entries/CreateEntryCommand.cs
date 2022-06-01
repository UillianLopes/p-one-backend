using POne.Core.CQRS;
using POne.Core.Enums;
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
        public EntryType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public ICollection<CreateEntryItem> Recurrences { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
        public string BarCode { get; set; }
        public string Currency { get; set; }
    }
}
