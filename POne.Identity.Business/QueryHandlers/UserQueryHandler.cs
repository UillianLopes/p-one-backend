using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Queries.Inputs.Users;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Business.QueryHandlers
{
    public class UserQueryHandler : IQueryHandler<GetUserSettings>, IQueryHandler<GetAuthenticatedUserSettings>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticatedUser _authenticatedUser;

        public UserQueryHandler(IUserRepository userRepository, IAuthenticatedUser authenticatedUser)
        {
            _userRepository = userRepository;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<IQueryOutput> Handle(GetAuthenticatedUserSettings request, CancellationToken cancellationToken)
        {
            var userSettings = await _userRepository
                .GetUserSettingsAsync(_authenticatedUser.Id, cancellationToken);

            if (userSettings == null)
                return QueryOutput.Ok(null);

            return QueryOutput.Ok(await userSettings.ReadAsync(cancellationToken));
        }

        public async Task<IQueryOutput> Handle(GetUserSettings request, CancellationToken cancellationToken)
        {
            var userSettings = await _userRepository
                .GetUserSettingsAsync(request.Id, cancellationToken);

            return QueryOutput.Ok(await userSettings.ReadAsync(cancellationToken));
        }
    }
}
