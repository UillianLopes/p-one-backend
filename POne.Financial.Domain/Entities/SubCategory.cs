using POne.Core.Entities;
using POne.Core.Events;
using System.Collections.Generic;

namespace POne.Financial.Domain.Entities
{
    public class SubCategory : OrganizationalEntity
    {

        protected SubCategory() : base()
        {
            Entries = new HashSet<Entry>();
        }

        public SubCategory(Category category, string name, string description, string color) : base(name, description, color)
        {
            Category = category;
            AddEvent(NotifyEvent.Success("Sub category created", $"The sub category {name} was created with success"));
        }

        public virtual ISet<Entry> Entries { get; private set; }
        public virtual Category Category { get; private set; }

        public void Update(string name, string description, string color, Category category)
        {
            Update(name, description, color);
            Category = category;
        }

    }
}
