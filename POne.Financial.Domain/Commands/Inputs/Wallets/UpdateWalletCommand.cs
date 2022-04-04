using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Wallets
{
    public class UpdateWalletCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public Guid? BankId { get; set; }
        public string Number { get; set; }
        public string Agency { get; set; }
        public string Color { get; set; }
    }
}
