using POne.Core.CQRS;
using System;

namespace POne.Identity.Domain.Queries.Inputs.Profiles
{
    public class GetProfileById : IQuery
    {
        public GetProfileById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
