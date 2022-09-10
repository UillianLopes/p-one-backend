using POne.Core.CQRS;
using POne.Core.Enums;

namespace POne.Financial.Domain.Queries.Inputs.Categories
{
    public class GetAllCategories : IQuery
    {
        public EntryOperation? Type { get; set; }
    }
}
