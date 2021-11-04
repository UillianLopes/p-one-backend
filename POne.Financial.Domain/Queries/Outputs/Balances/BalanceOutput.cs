using System;

namespace POne.Financial.Domain.Queries.Outputs.Balances
{
    public class BalanceOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
