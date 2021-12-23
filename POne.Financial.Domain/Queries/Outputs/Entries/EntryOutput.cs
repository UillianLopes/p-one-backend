using POne.Core.Enums;
using POne.Core.Extensions.Items;
using System;

namespace POne.Financial.Domain.Queries.Outputs.Entries
{
    public class EntryOutput
    {
        public Guid? RecurrenceId { get; set; }
        public int Index { get; set; }
        public EntryType Type { get; set; }
        public decimal Value { get; set; }
        public DateTime? DueDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AutoCompleteItem Category { get; set; }
        public AutoCompleteItem SubCategory { get; set; }
        public bool IsPaid { get; set; }
        public int Recurrences { get; set; }
        public Guid Id { get; set; }
        public string BarCode { get; set; }
    }
}
