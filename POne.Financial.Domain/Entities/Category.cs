using POne.Core.Entities;
using POne.Core.Enums;
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

        public Category(string name, string description, string color, EntryType type, Guid userId) : base(name, description, color)
        {
            UserId = userId;
            Type = type;
        }

        public Guid UserId { get; private set; }
        public EntryType Type { get; private set; }
        public virtual ISet<Entry> Entries { get; }
        public virtual ISet<SubCategory> SubCategories { get; }

        public void Update(string name, string description, string color, EntryType type)
        {
            Update(name, description, color);
            Type = type;
        }
    }
}
