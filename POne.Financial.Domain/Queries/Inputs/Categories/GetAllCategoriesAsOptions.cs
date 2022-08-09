using POne.Core.CQRS;
using POne.Core.Enums;

namespace POne.Financial.Domain.Queries.Inputs.Categories
{
    public class GetAllCategoriesAsOptions : IQuery
    {
        public EntryType? Type { get; set; }
    }
}
