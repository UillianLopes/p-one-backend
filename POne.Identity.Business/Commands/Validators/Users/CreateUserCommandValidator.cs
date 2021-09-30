using FluentValidation;
using POne.Identity.Business.Commands.Inputs.Users;

namespace POne.Identity.Business.Commands.Validators.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
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

            RuleFor(cm => cm.AccountName)
                .NotNull()
                .WithMessage("@PONE.MESSAGES.USERS.INVALID_ACCOUNT_NAME")
                .When(e => e.AccountId == null);

            RuleFor(cm => cm.AccountEmail)
                .NotNull()
                .WithMessage("@PONE.MESSAGES.USERS.INVALID_ACCOUNT_EMAIL")
                .When(e => e.AccountId == null);
        }
    }
}
