using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Balances
{
    public class UpdateBalanceCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
