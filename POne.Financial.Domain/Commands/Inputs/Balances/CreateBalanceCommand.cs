using POne.Core.CQRS;

namespace POne.Financial.Domain.Commands.Inputs.Balances
{
    public class CreateBalanceCommand : ICommand
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
