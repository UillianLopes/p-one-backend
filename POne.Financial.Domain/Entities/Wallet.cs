using POne.Core.Entities;
using POne.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POne.Financial.Domain.Entities
{
    public class Wallet : Entity
    {
        protected Wallet() : base()
        {
            Payments = new HashSet<Payment>();
            Balances = new HashSet<Balance>();
        }

        public Wallet(Guid userId, decimal value, string name, Bank bank, string number, string agency, BalanceType type, string color)
        {
            UserId = userId;
            Value = value;
            Name = name;
            Bank = bank;
            Number = number;
            Agency = agency;
            Type = type;
            Color = color;
        }

        public void Update(string name, Bank bank, string number, string agency, string color)
        {
            Name = name;
            Bank = bank;
            Number = number;
            Agency = agency;
            Color = color;
        }

        public Guid UserId { get; private set; }
        public decimal Value { get; private set; }
        public string Name { get; private set; }
        public string Number { get; private set; }
        public string Agency { get; private set; }
        public BalanceType Type { get; private set; }
        public string Color { get; private set; }
        public virtual Bank Bank { get; private set; }
        public virtual ISet<Payment> Payments { get; }
        public virtual ISet<Balance> Balances { get; }


        public virtual void Add(decimal value)
        {
            Value += value;

            UpdateBalance();
        }

        public virtual void Subtract(decimal value)
        {
            Value -= value;

            UpdateBalance();
        }

        protected virtual void UpdateBalance()
        {
            if (Balances.FirstOrDefault((balance) => balance.Creation.Date == DateTime.Now.Date) is Balance balance)
                balance.Update(Value);
            else
                Balances.Add(new Balance(Value, this));
        }
    }
}
