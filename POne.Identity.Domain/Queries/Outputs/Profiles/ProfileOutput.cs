using System;

namespace POne.Identity.Domain.Queries.Outputs.Profiles
{
    public class ProfileOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Roles { get; set; }
        public bool IsDefault { get; set; }
    }
}
