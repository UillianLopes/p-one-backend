using System.Collections.Generic;

namespace POne.Core.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public int CountryCode { get; private set; }
        public string Number { get; private set; }

        protected PhoneNumber() : base() { }

        public PhoneNumber(int countryCode, string number)
        {
            CountryCode = countryCode;
            Number = number;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CountryCode;
            yield return Number;
        }


    }
}
