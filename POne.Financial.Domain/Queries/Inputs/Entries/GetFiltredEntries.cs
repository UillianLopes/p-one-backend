using POne.Core.CQRS;
using POne.Core.Enums;
using System;

namespace POne.Financial.Domain.Queries.Inputs.Entries
{
    public class GetFiltredEntries : IQuery
    {

        public string Text { get; set; }
        public Guid[] Categories { get; set; }
        public Guid[] SubCategories { get; set; }
        public EntryType? Type { get; set; }
        public bool? IsPaid { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
    }
}
