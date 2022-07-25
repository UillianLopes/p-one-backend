using POne.Core.CQRS;
using System;

namespace POne.Identity.Business.Commands.Inputs.Users
{
    public class CreateUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Language { get; set; }
        public Guid ProfileId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
