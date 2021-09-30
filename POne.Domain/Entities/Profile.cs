using POne.Core.Entities;
using System.Collections.Generic;

namespace POne.Domain.Entities
{
    public class Profile : Entity
    {
        protected Profile() : base() { }

        public Profile(string name, string description) : this()
        {
            Name = name;
            Description = description;
            IsActive = true;
            Roles = new HashSet<Role>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public virtual ISet<Role> Roles { get; private set; }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

    }
}
