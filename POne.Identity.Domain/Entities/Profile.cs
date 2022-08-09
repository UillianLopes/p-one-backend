using POne.Core.Entities;
using System;
using System.Collections.Generic;

namespace POne.Identity.Domain.Entities
{
    public class Profile : Entity
    {
        protected Profile() : base() { }

        public Profile(string name, string description) : this()
        {
            Name = name;
            Description = description;
            Roles = new HashSet<Role>();
            Users = new HashSet<User>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsDefault { get; private set; }
        public virtual Account Account { get; private set; }
        public virtual ISet<Role> Roles { get; private set; }
        public virtual ISet<User> Users { get; private set; }

        public void Toggle(Role role)
        {
            if (!Roles.Contains(role))
                Roles.Add(role);
            else
                Roles.Remove(role);
        }
    }
}
