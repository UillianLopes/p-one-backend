using POne.Core.Entities;
using POne.Core.ValueObjects;

namespace POne.Identity.Domain.Entities
{
    public class Contact : Entity
    {
        protected Contact() : base() { }

        public Contact(User user, PhoneNumber number, string name) : this()
        {
            User = user;
            Number = number;
            Name = name;
        }

        public virtual User User { get; private set; }
        public virtual PhoneNumber Number { get; private set; }
        public string Name { get; private set; }
    }
}
