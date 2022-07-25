using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Core.ValueObjects;
using POne.Identity.Business.Commands.Inputs.Users;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using POne.Identity.Domain.Settings;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Business.CommandHandlers
{
    public class UserCommandHandler : ICommandHandler<CreateUserCommand>, ICommandHandler<UpdateUserCommand>, ICommandHandler<AuthenticateUserCommand>, ICommandHandler<UpdateUserSettingsCommand>
    {
        private readonly IUserRepository _userRepository;

        private readonly IAuthenticatedUser _authenticatedUser;

        public UserCommandHandler(IUserRepository userRepository, IAuthenticatedUser authenticatedUser)
        {
            _userRepository = userRepository;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<ICommandOuput> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByEmail(request.Email, cancellationToken) is not null)
                return CommandOutput.BadRequest("@PONE.MESSAGES.EMAIL_ALREADY_EXISTS");

            var user = new User(request.Name, request.Email, request.DateOfBirth, null, new Password(request.Password), null);

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
    }
}
