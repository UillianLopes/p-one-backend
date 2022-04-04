using POne.Core.Entities;
using System;

namespace POne.Financial.Domain.Entities
{
    public class Balance : Entity
    {
        protected Balance() : base() { }

        public Balance(decimal value, Wallet wallet) : this()
        {
            Value = value;
            Wallet = wallet;
        }

        public decimal Value { get; private set; }
        public virtual Wallet Wallet { get; private set; }

        public void Update(decimal value)
        {
            Value = value;
            LastUpdate = DateTime.Now;
        }

    }
}
