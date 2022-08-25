using System.Collections.Generic;

namespace POne.Core.ValueObjects
{
    public class MonthReference : ValueObject
    {
        public int Month { get; set; }
        public int Year { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Year;
            yield return Month;
        }
    }
}
