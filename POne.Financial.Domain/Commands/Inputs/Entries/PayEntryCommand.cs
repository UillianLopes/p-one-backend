using POne.Core.CQRS;
using System;
using System.Text.Json.Serialization;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class PayEntryCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public decimal Fees { get; set; }
        public decimal Fine { get; set; }
        public Guid WalletId { get; set; }
        public decimal? NewValue { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
