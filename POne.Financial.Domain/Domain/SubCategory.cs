using POne.Core.Entities;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Domain
{
    public class SubCategory : OrganizationalEntity
    {

        protected SubCategory() : base()
        {
            Entries = new HashSet<Entry>();
        }

        public SubCategory(Category category, string name, string description) : base(name, description)
        {
            Category = category;
        }

        public virtual ISet<Entry> Entries { get; private set; }
        public virtual Category Category { get; private set; }

        public void Update(string name, string description, Category category)
        {
            Update(name, description);
            Category = category;
        }

    }
}
