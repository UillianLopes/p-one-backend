using POne.Core.CQRS;
using System;

namespace POne.Identity.Domain.Queries.Inputs.Users
{
    public class GetAllUsers : IQuery
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
        public string Text { get; set; }
        public Guid[] ProfileIds { get; set; }
        public bool WithAmmount { get; set; } = false;
    }
}
