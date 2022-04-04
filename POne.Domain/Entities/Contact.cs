using POne.Core.Entities;
using POne.Core.ValueObjects;

namespace POne.Domain.Entities
{
    public class Contact : Entity
    {
        public User User { get; private set; }
        public virtual PhoneNumber Number { get; private set; }
        public virtual string Name { get; private set; }
    }
}
