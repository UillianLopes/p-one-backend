using POne.Core.ValueObjects;

namespace POne.Financial.Domain.Queries.Inputs.Home
{
    public abstract class GetBalance
    {
        public MonthReference Month { get; set; }
    }
}
