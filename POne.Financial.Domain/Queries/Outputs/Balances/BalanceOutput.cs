using POne.Financial.Domain.Queries.Outputs.Banks;
using System;

namespace POne.Financial.Domain.Queries.Outputs.Balances
{
    public class BalanceOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Number { get; set; }
        public string Agency { get; set; }
        public BankOutput Bank { get; set; }
    }
}
