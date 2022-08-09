using POne.Core.CQRS;

namespace POne.Identity.Domain.Queries.Inputs.Profiles
{
    public class GetAllProfiles : IQuery
    {
        public string Name { get; set; } = string.Empty;
    }
}
