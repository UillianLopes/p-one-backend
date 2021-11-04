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

        public string Name { get; private set; }
        public string Description { get; private set; }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
