using System.Collections.Generic;

namespace POne.Identity.Domain.Entities
{
    public class Role
    {
        protected Role() { }

        public Role(string key) : this()
        {
            Key = key;
            Profiles = new HashSet<Profile>();
        }

        public string Key { get; private set; }
        public virtual ISet<Profile> Profiles { get; private set; }
    }
}
