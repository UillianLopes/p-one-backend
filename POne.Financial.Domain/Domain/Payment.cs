using POne.Core.Entities;

namespace POne.Financial.Domain.Domain
{
    public class Payment : Entity
    {
        protected Payment() : base() { }

        public Payment(Entry entry, decimal value) : this()
        {
            Entry = entry;
            Value = value;
        }

        public virtual Entry Entry { get; private set; }
        public decimal Value { get; private set; }
    }
}
