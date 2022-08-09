using POne.Core.Entities;
using System.Collections.Generic;

namespace POne.Identity.Domain.Entities
{
    public class Account : Entity
    {
        protected Account() : base()
        {
            Profiles = new HashSet<Profile>();
            Users = new HashSet<User>();
        }

        public Account(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual ISet<Profile> Profiles { get; private set; }
        public virtual ISet<User> Users { get; private set; }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Add(Profile profile) => Profiles.Add(profile);

        public void Remove(Profile profile) => Profiles.Remove(profile);

    }
}
