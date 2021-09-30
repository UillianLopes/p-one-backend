using POne.Core.CQRS;

namespace POne.Identity.Business.Commands.Inputs.Users
{
    public class AuthenticateUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
