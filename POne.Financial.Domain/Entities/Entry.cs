using POne.Core.Entities;
using POne.Core.Enums;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Entities
{
    public class Entry : Entity
    {
        public Entry(
            Guid userId,
            Guid? recurrenceId,
            int index,
            int recurrences,
            EntryType type,
            decimal value,
            DateTime dueDate,
            string title,
            string barCode,
            string description,
            Category category,
            SubCategory subCategory
        ) : this()
        {
            UserId = userId;
            RecurrenceId = recurrenceId;
            Recurrences = recurrences;
            Type = type;
            Value = value;
            DueDate = dueDate;
            Title = title;
            BarCode = barCode;
            Description = description;
            Category = category;
            SubCategory = subCategory;
            Index = index;
        }

        protected Entry() : base()
        {
            Payments = new HashSet<Payment>();
        }

        public Guid UserId { get; private set; }
        public Guid? RecurrenceId { get; private set; }
        public int Recurrences { get; private set; }
        public int Index { get; private set; }
        public EntryType Type { get; private set; }
        public decimal Value { get; private set; }
        public DateTime DueDate { get; private set; }
        public string Title { get; private set; }
        public string BarCode { get; private set; }
        public string Description { get; private set; }
        public virtual Category Category { get; private set; }
        public virtual SubCategory SubCategory { get; private set; }
        public virtual ISet<Payment> Payments { get; private set; }

        public void Pay(Wallet wallet, decimal value, decimal fees = 0.00m, decimal fine = 0.00m)
        {
            var payment = new Payment(value, fees, fine, this, wallet);

            Payments.Add(payment);

            if (Type == EntryType.Credit)
                wallet.Add(value);
            else
                wallet.Subtract(value);
        }
    }
}
