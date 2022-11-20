using POne.Core.Entities;
using POne.Core.Enums;
using POne.Core.Events;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Entities
{
    public class Category : OrganizationalEntity
    {
        protected Category() : base()
        {
            Entries = new HashSet<Entry>();
            SubCategories = new HashSet<SubCategory>();
        }

        public Category(Guid? userId, Guid? accountId, string name, string description, string color, EntryOperation operation) : base(name, description, color)
        {
            UserId = userId;
            AccountId = accountId;
            Operation = operation;
            AddEvent(NotifyEvent.Success("Category created", $"The category {name} was created with success"));            
        }

        public Guid? UserId { get; private set; }
        public Guid? AccountId { get; private set; }
        public EntryOperation Operation { get; private set; }
        public virtual ISet<Entry> Entries { get; }
        public virtual ISet<SubCategory> SubCategories { get; }

        public void Update(string name, string description, string color, EntryOperation type)
        {
            Update(name, description, color);
            Operation = type;
        }
    }
}
