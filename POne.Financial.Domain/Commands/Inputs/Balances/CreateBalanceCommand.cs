using POne.Core.CQRS;
using POne.Core.Enums;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Balances
{
    public class CreateBalanceCommand : ICommand
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public Guid? BankId { get; set; }
        public string Number { get; set; }
        public string Agency { get; set; }
        public BalanceType Type { get; set; }
    }
}
