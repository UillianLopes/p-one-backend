using POne.Core.CQRS;
using POne.Core.ValueObjects;
using POne.Domain.Entities;
using POne.Identity.Business.Commands.Inputs.Users;
using POne.Identity.Domain.Contracts.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Business.CommandHandlers
{
    public class UserCommandHandler : ICommandHandler<CreateUserCommand>, ICommandHandler<UpdateUserCommand>, ICommandHandler<AuthenticateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accoutRepository;

        public UserCommandHandler(IUserRepository userRepository, IAccountRepository accoutRepository)
        {
            _userRepository = userRepository;
            _accoutRepository = accoutRepository;
        }

        private async Task<ICommandOuput> CreateAccountAndUserAsync(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var account = new Account(request.AccountName, request.AccountEmail);

            var user = new User(
                request.Name,
                request.Email,
                request.BirthDate,
                new Address(
                    request.Street,
                    request.District,
                    request.Number,
                    request.City,
                    request.State,
                    request.Complement,
                    request.ZipCode
                ),
                new PhoneNumber(55, request.MobilePhone),
                new Password(request.Password),
                account
            );


            account.AddUser(user);

            await _accoutRepository.CreateAync(account, cancellationToken);

            return CommandOutput.Created($"User/{user.Id}", new
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
                MobilePhone = new
                {
                    user.MobilePhone.Number,
                    user.MobilePhone.CountryCode
                },
            }, "@PONE.MESSAGES.USER_CREATED");

        }

        private async Task<ICommandOuput> CreateUserInExistingAccountAsync(CreateUserCommand request, Account account, CancellationToken cancellationToken)
        {
            var user = new User(
                request.Name,
                request.Email,
                request.BirthDate,
                new Address(
                    request.Street,
                    request.District,
                    request.Number,
                    request.City,
                    request.State,
                    request.Complement,
                    request.ZipCode
                ),
                new PhoneNumber(55, request.MobilePhone),
                new Password(request.Password),
                account
            );


            account.AddUser(user);

            await _accoutRepository.UpdateAsync(account, cancellationToken);

            return CommandOutput.Created($"User/{user.Id}", new
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
                MobilePhone = new
                {
                    user.MobilePhone.Number,
                    user.MobilePhone.CountryCode
                }

            }, "@PONE.MESSAGES.USER_CREATED");
        }

        public async Task<ICommandOuput> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request.AccountId is not Guid accountId)
                return await CreateAccountAndUserAsync(request, cancellationToken);
            else if (await _accoutRepository.FindByIdAync(accountId, cancellationToken) is Account account)
                return await CreateUserInExistingAccountAsync(request, account, cancellationToken);

            return CommandOutput.BadRequest("@PONE.MESSAGES.INVALID_ACCOUNT_ID");
        }

        public async Task<ICommandOuput> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByIdAync(request.Id, cancellationToken) is not User user)
                return CommandOutput.NotFound("@PONE.MESSAGES.USER_NOT_FOUND");

            user.Update(request.Name, request.Email, request.BirthDate);
            user.UpdateAddress(request.Street, request.District, request.Number, request.City, request.State, request.Country, request.ZipCode);

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
                MobilePhone = new
                {
                    user.MobilePhone.Number,
                    user.MobilePhone.CountryCode
                }
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
    }
}
