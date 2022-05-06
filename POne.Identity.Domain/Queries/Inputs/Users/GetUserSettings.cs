using POne.Core.CQRS;
using System;

namespace POne.Identity.Domain.Queries.Inputs.Users
{
    public class GetUserSettings : IQuery
    {
        public Guid Id { get; set; }
    }
}
