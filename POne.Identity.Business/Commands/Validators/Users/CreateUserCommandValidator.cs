using FluentValidation;
using POne.Identity.Business.Commands.Inputs.Users;

namespace POne.Identity.Business.Commands.Validators.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateStandaloneUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(cm => cm.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("@PONE.MESSAGES.USERS.INVALID_PASSWORD");

            RuleFor(cm => cm.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("@PONE.MESSAGES.USERS.INVALID_NAME");

            RuleFor(cm => cm.Email)
                .EmailAddress()
                .NotNull()
                .NotEmpty()
                .WithMessage("@PONE.MESSAGES.USERS.INVALID_EMAIL");
        }
    }
}
