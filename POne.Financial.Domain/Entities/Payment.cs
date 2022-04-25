using POne.Core.Entities;

namespace POne.Financial.Domain.Entities
{
    public class Payment : Entity
    {
        protected Payment() : base() { }

        public Payment(decimal value, decimal fees, decimal fine, Entry entry, Wallet wallet) : this()
        {
            Value = value;
            Fees = fees;
            Fine = fine;
            Entry = entry;
            Wallet = wallet;
        }

        public decimal Value { get; private set; }
        public decimal Fees { get; private set; }
        public decimal Fine { get; private set; }
        public virtual Entry Entry { get; private set; }
        public virtual Wallet Wallet { get; private set; }
    }
}
