using POne.Core.Enums;
using POne.Financial.Domain.Queries.Outputs.Banks;
using System;

namespace POne.Financial.Domain.Queries.Outputs.Wallets
{
    public class WalletOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Number { get; set; }
        public string Agency { get; set; }
        public BankOutput Bank { get; set; }
        public BalanceType Type { get; set; }
        public string Color { get; set; }
        public string Currency { get; set; }
    }
}
