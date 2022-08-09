using POne.Core.CQRS;
using System;

namespace POne.Identity.Business.Commands.Inputs.Users
{
    public class CreateStandaloneUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Language { get; set; }
        public Guid ProfileId { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressCommand Address { get; set; }
    }
}
