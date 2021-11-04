using POne.Core.Entities;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Domain
{
    public class Balance : Entity
    {
        protected Balance() : base()
        {
        }

        public Balance(Guid userId, string name, decimal value) : this()
        {
            UserId = userId;
            Value = value;
            Name = name;
        }

        public Guid UserId { get; private set; }
        public decimal Value { get; private set; }
        public string Name { get; private set; }

        public virtual ISet<Payment> Payments { get; private set; }

        public virtual void Add(decimal value) => Value += value;
        public virtual void Subtract(decimal value) => Value -= value;

        public void Update(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }
}
