using POne.Core.CQRS;
using System;

namespace POne.Identity.Domain.Queries.Inputs.Profiles
{
    public class GetAllRoles : IQuery
    {
        public GetAllRoles(Guid profileId)
        {
            ProfileId = profileId;
        }

        public Guid ProfileId { get; set; }
    }
}
