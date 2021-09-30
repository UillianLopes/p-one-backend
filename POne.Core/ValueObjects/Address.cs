using System.Collections.Generic;

namespace POne.Core.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string District { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        protected Address() : base() { }

        public Address(string street, string district, string number, string city, string state, string country, string zipCode) : this()
        {
            Street = street;
            District = district;
            Number = number;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return District;
            yield return Number;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}
