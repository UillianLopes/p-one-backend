namespace POne.Core.Entities
{
    public abstract class OrganizationalEntity : Entity
    {
        protected OrganizationalEntity() : base() { }

        public OrganizationalEntity(string name, string description, string color) : this()
        {
            Name = name;
            Description = description;
            Color = color;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Color { get; private set; }

        public void Update(string name, string description, string color)
        {
            Name = name;
            Description = description;
            Color = color;
        }
    }
}
