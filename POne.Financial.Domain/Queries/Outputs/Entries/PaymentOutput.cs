using POne.Core.Models;

namespace POne.Financial.Domain.Queries.Outputs.Entries
{
    public class PaymentOutput
    {
        public decimal Value { get; set; }
        public decimal Fees { get; set; }
        public decimal Fine { get; set; }
        public OptionModel Wallet { get; set; }
    }
}
