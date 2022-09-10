using POne.Core.CQRS;
using POne.Core.Enums;

namespace POne.Financial.Domain.Queries.Inputs.Categories
{
    public class GetAllCategoriesAsOptions : IQuery
    {
        public EntryOperation? Operation { get; set; }
    }
}
