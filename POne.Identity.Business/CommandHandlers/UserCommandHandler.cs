using POne.Core.CQRS;
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

        public async Task<ICommandOuput> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Account account;

            if (request.AccountId is not Guid accountId)
            {
                account = request;
                await _accoutRepository.CreateAync(account, cancellationToken);
            }
            else if (await _accoutRepository.FindByIdAync(accountId, cancellationToken) is Account searchedAccount)
                account = searchedAccount;
            else return CommandOutput.BadRequest("@PONE.MESSAGES.INVALID_ACCOUNT_ID");

            User user = request;

            await _userRepository.CreateAync(request, cancellationToken);

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
