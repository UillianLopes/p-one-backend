using POne.Core.Entities;
using POne.Core.Enums;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Domain
{
    public class Balance : Entity
    {
        protected Balance() : base()
        {
        }

        public Balance(Guid userId, decimal value, string name, Bank bank, string number, string agency, BalanceType type)
        {
            UserId = userId;
            Value = value;
            Name = name;
            Bank = bank;
            Number = number;
            Agency = agency;
            Type = type;
        }

        public Guid UserId { get; private set; }
        public decimal Value { get; private set; }
        public string Name { get; private set; }
        public string Number { get; private set; }
        public string Agency { get; private set; }
        public BalanceType Type { get; private set; }
        public virtual Bank Bank { get; private set; }
        public virtual ISet<Payment> Payments { get; }

        public virtual void Add(decimal value) => Value += value;
        public virtual void Subtract(decimal value) => Value -= value;

        public void Update(decimal value, string name, Bank bank, string number, string agency)
        {
            Value = value;
            Name = name;
            Bank = bank;
            Number = number;
            Agency = agency;
        }


    }
}
