using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Api.Identity
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;

        public ProfileService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            if (context.Subject is not ClaimsPrincipal principal)
                throw new ArgumentException(nameof(principal));

            var subjectId = principal.Claims?.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value;

            var cancellationTokenSource = new CancellationTokenSource();

            if (await _userRepository.FindByIdAync(new Guid(subjectId), cancellationTokenSource.Token) is not User user || user.IsDeleted)
                throw new ArgumentException("Invalid user");

            context.IssuedClaims = user
                .ReadRoles()
                .ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            if (context.Subject is not ClaimsPrincipal principal)
                throw new ArgumentException(nameof(principal));

            var subjectId = principal
                .Claims?
                .FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?
                .Value;

            var cancellationTokenSource = new CancellationTokenSource();

            context.IsActive = !(await _userRepository.FindByIdAync(new Guid(subjectId), cancellationTokenSource.Token) is not User user || user.IsDeleted);
        }
    }
}
