using POne.Core.CQRS;
using System;
using System.Text.Json.Serialization;

namespace POne.Financial.Domain.Commands.Inputs.Wallets
{
    public class DepositCommand : ICommand
    {
        [JsonIgnore]
        public Guid WalletId { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public decimal Deposit { get; set; }
    }
}
