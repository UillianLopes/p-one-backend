namespace POne.Core.Entities
{
    public abstract class OrganizationalEntity : Entity
    {
        protected OrganizationalEntity() : base() { }

        public OrganizationalEntity(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
