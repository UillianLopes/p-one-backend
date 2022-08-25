using POne.Core.Entities;
using POne.Core.Enums;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Entities
{
    public class Entry : Entity
    {
        public Entry(
            Guid? userId,
            Guid? accountId,
            Guid? installmentId,
            int? index,
            int? installments,
            EntryOperation operation,
            decimal value,
            DateTime dueDate,
            string title,
            string barCode,
            string description,
            Category category,
            SubCategory subCategory,
            string currency
        ) : this()
        {
            UserId = userId;
            AccountId = accountId;
            InstallmentId = installmentId;
            Installments = installments;
            Operation = operation;
            Value = value;
            DueDate = dueDate;
            Title = title;
            BarCode = barCode;
            Description = description;
            Category = category;
            SubCategory = subCategory;
            Index = index;
            Currency = currency;
        }

        protected Entry() : base()
        {
            Payments = new HashSet<Payment>();
        }

        public DateTime DueDate { get; private set; }
        public decimal Value { get; private set; }
        public EntryOperation Operation { get; private set; }
        public Guid? AccountId { get; private set; }
        public Guid? InstallmentId { get; private set; }
        public Guid? UserId { get; private set; }
        public int? Index { get; private set; }
        public int? Installments { get; private set; }
        public string BarCode { get; private set; }
        public string Currency { get; private set; }
        public string Description { get; private set; }
        public string Title { get; private set; }

        public EntryRecurrence? Recurrence { get; private set; }
        public DateTime? Begin { get; private set; }
        public DateTime? End { get; private set; }
        public int? RecurrenceDay { get; private set; }

        public virtual Entry Parent { get; private set; }
        public virtual Category Category { get; private set; }
        public virtual SubCategory SubCategory { get; private set; }
        public virtual ISet<Payment> Payments { get; private set; }
        public virtual ISet<Entry> Children { get; private set; }

        public void Update(
            string title,
            string description,
            string barCode,
            string currency,
            decimal value,
            DateTime dueDate,
            Category category,
            SubCategory subCategory
        )
        {
            DueDate = dueDate;
            Title = title;
            Description = description;
            BarCode = barCode;
            Currency = currency;
            Value = value;
            Category = category;
            SubCategory = subCategory;
        }

        public void Pay(Wallet wallet, decimal value, decimal fees = 0.00m, decimal fine = 0.00m)
        {
            var payment = new Payment(value, fees, fine, this, wallet);

            Payments.Add(payment);

            if (Operation == EntryOperation.Credit)
                wallet.Add(value);
            else
                wallet.Subtract(value);
        }

        public void RevertPayments()
        {
            foreach (var payment in Payments)
                payment.Revert();
        }
    }
}
