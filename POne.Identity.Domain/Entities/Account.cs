using POne.Core.Entities;

namespace POne.Identity.Domain.Entities
{
    public class Account : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
