using POne.Core.CQRS;
using POne.Core.Enums;
using System;
using System.Text.Json.Serialization;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class UpdateEntryCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public EntryType Type { get; private set; }
        public EntryRecurrence Recurrence { get; private set; }
        public decimal Value { get; private set; }
        public decimal Fees { get; private set; }
        public decimal Fine { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public virtual Guid CategoryId { get; private set; }
        public virtual Guid SubCategoryId { get; private set; }
    }
}
