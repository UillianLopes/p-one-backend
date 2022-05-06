using POne.Core.Entities;
using System.Collections.Generic;

namespace POne.Identity.Domain.Entities
{
    public class Role : Entity
    {
        protected Role() : base() { }

        public Role(string name, string description, string key) : this()
        {
            Name = name;
            Description = description;
            IsActive = true;
            Key = key;

            Users = new HashSet<User>();
            Profiles = new HashSet<Profile>();
        }

        public string Key { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }

        public virtual ISet<User> Users { get; private set; }
        public virtual ISet<Profile> Profiles { get; private set; }

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
