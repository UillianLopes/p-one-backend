﻿using POne.Core.Entities;
using POne.Core.Enums;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Entities
{
    public class Wallet : Entity
    {
        protected Wallet() : base()
        {
            Payments = new HashSet<Payment>();
            Balances = new HashSet<Balance>();
            Entries = new HashSet<Entry>();
        }

        public Wallet(
            Guid? userId,
            Guid? accountId,
            decimal value,
            string name,
            Bank bank,
            string number,
            string agency,
            BalanceType type,
            string color,
            string currency
        ) : this()
        {
            UserId = userId;
            AccountId = accountId;
            Value = value;
            Name = name;
            Bank = bank;
            Number = number;
            Agency = agency;
            Type = type;
            Color = color;
            Currency = currency;
        }

        public void Update(string name, Bank bank, string number, string agency, string color, string currency)
        {
            Name = name;
            Bank = bank;
            Number = number;
            Agency = agency;
            Color = color;
            Currency = currency;
        }

        public Guid? UserId { get; private set; }
        public Guid? AccountId { get; private set; }
        public decimal Value { get; private set; }
        public string Name { get; private set; }
        public string Number { get; private set; }
        public string Agency { get; private set; }
        public BalanceType Type { get; private set; }
        public string Color { get; private set; }
        public string Currency { get; private set; }
        public virtual Bank Bank { get; private set; }
        public virtual ISet<Payment> Payments { get; }
        public virtual ISet<Balance> Balances { get; }
        public virtual ISet<Entry> Entries { get; }

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
            Balances.Add(new Balance(Value, this));
        }
    }
}
