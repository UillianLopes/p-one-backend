using POne.Core.CQRS;
using System;

namespace POne.Identity.Business.Commands.Inputs.Users
{
    public class CreateUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public int CountryCode { get; set; }
        public string Password { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ReferencePoint { get; set; }
        public string Complement { get; set; }
        public Guid? AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountEmail { get; set; }

    }
}
