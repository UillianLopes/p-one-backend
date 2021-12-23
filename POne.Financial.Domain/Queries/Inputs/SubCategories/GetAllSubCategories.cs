using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Queries.Inputs.SubCategories
{
    public class GetAllSubCategories : IQuery
    {
        public Guid? CategoryId { get; set; }
    }
}
