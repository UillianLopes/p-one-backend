using POne.Core.Entities;
using POne.Core.Enums;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Domain
{
    public class Entry : Entity
    {
        public Entry(
            Guid userId,
            Guid? recurrenceId,
            int index,
            EntryType type, 
            decimal value,
            DateTime? dueDate, 
            string title,
            string description, 
            Category category,
            SubCategory subCategory
        ) : this()
        {
            UserId = userId;
            RecurrenceId = recurrenceId;
            Type = type;
            Value = value;
            DueDate = dueDate;
            Title = title;
            Description = description;
            Category = category;
            SubCategory = subCategory;
            Index = index;
        }

        protected Entry() : base()
        {
        }

        public Guid UserId { get; private set; }
        public Guid? RecurrenceId { get; private set; }
        public int Index { get; private set; }
        public EntryType Type { get; private set; }
        public decimal Value { get; private set; }
        public DateTime? DueDate { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public virtual Category Category { get; private set; }
        public virtual SubCategory SubCategory { get; private set; }
        public virtual ISet<Payment> Payments { get; private set; }

        public void Pay(Balance balance, decimal value, decimal fees = 0.00m, decimal fine = 0.00m)
        {
            var payment = new Payment(value, fees, fine, this, balance);

            Payments.Add(payment);

            if (Type == EntryType.Credit)
                balance.Add(value);
            else
                balance.Subtract(value);
        }
    }
}
