using POne.Core.CQRS;
using POne.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POne.Identity.Business.Commands.Inputs.Users
{
    public class AddressCommand : ICommand
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ReferencePoint { get; set; }
        public string Complement { get; set; }

        public Address BuildAddress()
        {
            return new Address(Street, District, Number, City, State, Country, ZipCode);
        }
    }
}
