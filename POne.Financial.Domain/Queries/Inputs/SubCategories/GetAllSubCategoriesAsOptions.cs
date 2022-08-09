using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Queries.Inputs.SubCategories
{
    public class GetAllSubCategoriesAsOptions : IQuery
    {
        public Guid? CategoryId { get; set; }
    }
}
