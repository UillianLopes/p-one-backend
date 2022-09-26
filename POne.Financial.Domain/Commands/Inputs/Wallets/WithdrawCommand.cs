using POne.Core.CQRS;
using System;
using System.Text.Json.Serialization;

namespace POne.Financial.Domain.Commands.Inputs.Wallets
{
    public class WithdrawCommand : ICommand
    {
        [JsonIgnore]
        public Guid WalletId { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public decimal Withdraw { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}
