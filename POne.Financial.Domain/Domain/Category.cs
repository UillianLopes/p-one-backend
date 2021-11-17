using POne.Core.Entities;
using POne.Core.Enums;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Domain
{
    public class Category : OrganizationalEntity
    {
        protected Category() : base()
        {
            Entries = new HashSet<Entry>();
            SubCategories = new HashSet<SubCategory>();
        }

        public Category(string name, string description, EntryType type, Guid userId, Guid? accountId) : base(name, description)
        {
            UserId = userId;
            AccountId = accountId;
            Type = type;
        }

        public Guid? AccountId { get; private set; }
        public Guid UserId { get; private set; }
        public EntryType Type { get; private set; }
        public virtual ISet<Entry> Entries { get; private set; }
        public virtual ISet<SubCategory> SubCategories { get; private set; }

        public void Update(string name, string description, EntryType type)
        {
            Update(name, description);
            Type = type;
        }
    }
}
