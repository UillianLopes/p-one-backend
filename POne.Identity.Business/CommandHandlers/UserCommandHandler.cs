using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Core.ValueObjects;
using POne.Identity.Business.Commands.Inputs.Users;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using POne.Identity.Domain.Settings;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Business.CommandHandlers
{
    public class UserCommandHandler : 
        ICommandHandler<CreateStandaloneUserCommand>, 
        ICommandHandler<UpdateUserCommand>, 
        ICommandHandler<AuthenticateUserCommand>, 
        ICommandHandler<UpdateUserSettingsCommand>,
        ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly IProfileRepository _profileRepository;

        public UserCommandHandler(IUserRepository userRepository, IAccountRepository accountRepository, IAuthenticatedUser authenticatedUser, IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _authenticatedUser = authenticatedUser;
            _profileRepository = profileRepository;
        }

        public async Task<ICommandOuput> Handle(CreateStandaloneUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByEmail(request.Email, cancellationToken) is not null)
                return CommandOutput.BadRequest("@PONE.MESSAGES.EMAIL_ALREADY_EXISTS");

            if (request.Password != request.PasswordConfirmation)
                return CommandOutput.BadRequest("@PONE.MESSAGES.PASSWORD_DOES_NOT_MATCH");

            var user = User.Standalone(
                request.Name,
                request.Email,
                new Password(request.Password),
                request.BirthDate,
                request.Address?.BuildAddress()
            ); ;

            await user.UpdateUserSettingsAsync(new GeneralSettings { Language = request.Language }, cancellationToken);

            await _userRepository.CreateAync(user, cancellationToken);

            return CommandOutput.Created($"User/{user.Id}", new
            {
                user.Id,
                user.Name
            }, "@PONE.MESSAGES.USER_CREATED");
        }

        public async Task<ICommandOuput> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByIdAync(request.Id, cancellationToken) is not User user)
                return CommandOutput.NotFound("@PONE.MESSAGES.USER_NOT_FOUND");

            user.Update(request.Name, request.Email, request.BirthDate);

            if (request.Address is AddressCommand address)
                user.UpdateAddress(
                    address.Street,
                    address.District,
                    address.Number,
                    address.City,
                    address.State,
                    address.Country,
                    address.ZipCode
                 );

            return CommandOutput.Ok(new
            {
                user.Id,
                user.Creation,
                user.LastUpdate,
                user.Name,
                user.Email,
                user.BirthDate,
                Address = new
                {
                    user.Address.Street,
                    user.Address.District,
                    user.Address.Number,
                    user.Address.City,
                    user.Address.State,
                    user.Address.Country,
                    user.Address.ZipCode
                },
                Contacts = user.Contacts.Select(c => new
                {
                    c.Id,
                    c.Number,
                })
            }, "@PONE.MESSAGES.USER_UPDATED");

        }

        public async Task<ICommandOuput> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByEmail(request.Email, cancellationToken) is not User user)
                return CommandOutput.Unauthorized("@PONE.MESSAGES.INVALID_EMAIL_OR_PASSWORD");

            if (user.Password != request.Password)
                return CommandOutput.Unauthorized("@PONE.MESSAGES.INVALID_EMAIL_OR_PASSWORD");

            return CommandOutput.Ok("@PONE.MESSAGES.AUTHENTICATED_WITH_SUCCESS");
        }

        public async Task<ICommandOuput> Handle(UpdateUserSettingsCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByIdAync(_authenticatedUser.Id, cancellationToken) is not User user)
                return CommandOutput.NotFound("@PONE.MESSAGES.USER_NOT_FOUND");

            await user.UpdateUserSettingsAsync(request, cancellationToken);

            return CommandOutput.Ok("@PONE.MESSAGES.USER_SETTINGS_UPDATED_WITH_SUCCESS");
        }

        public async Task<ICommandOuput> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByEmail(request.Email, cancellationToken) is not null)
                return CommandOutput.BadRequest("@PONE.MESSAGES.EMAIL_ALREADY_EXISTS");

            if (request.Password != request.PasswordConfirmation)
                return CommandOutput.BadRequest("@PONE.MESSAGES.PASSWORD_DOES_NOT_MATCH");

            if (!(_authenticatedUser.AccountId is Guid accountId && accountId != Guid.Empty && await _accountRepository.FindByIdAync(accountId, cancellationToken) is Account account))
                return CommandOutput.BadRequest("");

            if (await _profileRepository.FindByIdAync(accountId, cancellationToken) is not Profile profile)
                return CommandOutput.BadRequest("@PONE.MESSAGES.PROFILE_NOT_FOUND");

            var user = User.WithAccount(
                request.Name,
                request.Email,
                new Password(request.Password),
                request.BirthDate,
                request.Address?.BuildAddress(),                
                profile,
                account
            ); ;

            await user.UpdateUserSettingsAsync(new GeneralSettings { Language = request.Language }, cancellationToken);

            await _userRepository.CreateAync(user, cancellationToken);

            return CommandOutput.Created($"User/{user.Id}", new
            {
                user.Id,
                user.Name
            }, "@PONE.MESSAGES.USER_CREATED");
        }
    }
}
