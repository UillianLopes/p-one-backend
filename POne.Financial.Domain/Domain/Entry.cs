using POne.Core.Entities;
using POne.Core.Enums;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Domain
{
    public class Entry : Entity
    {
        protected Entry() : base()
        {
            Payments = new HashSet<Payment>();
        }

        public Entry(Guid userId, EntryType type, EntryRecurrence recurrence, decimal value, decimal fees, decimal fine, string title, string description, Category category, SubCategory subCategory) : this()
        {
            UserId = userId;
            Type = type;
            Recurrence = recurrence;
            Value = value;
            Fees = fees;
            Fine = fine;
            Title = title;
            Description = description;
            Category = category;
            SubCategory = subCategory;
        }

        public Guid UserId { get; private set; }
        public EntryType Type { get; private set; }
        public EntryRecurrence Recurrence { get; private set; }
        public decimal Value { get; private set; }
        public decimal Fees { get; private set; }
        public decimal Fine { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public virtual Category Category { get; private set; }
        public virtual SubCategory SubCategory { get; private set; }
        public virtual ISet<Payment> Payments { get; private set; }
    }
}
