using IdentityModel;
using IdentityServer4.Validation;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Api.Identity
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {

        private readonly IUserRepository _userRepository;

        public ResourceOwnerPasswordValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            if (await _userRepository.FindByEmail(context.UserName, cancellationTokenSource.Token) is not User user)
                return;

            if (user.Password != context.Password)
                return;

            context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
