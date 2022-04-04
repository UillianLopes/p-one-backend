using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using POne.Domain.Entities;
using POne.Identity.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
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

            var claims = ReadClaimsFromUser(user);

            context.IssuedClaims = claims.ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            if (context.Subject is not ClaimsPrincipal principal)
                throw new ArgumentException(nameof(principal));

            var subjectId = principal.Claims?.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value;

            var cancellationTokenSource = new CancellationTokenSource();

            context.IsActive = !(await _userRepository.FindByIdAync(new Guid(subjectId), cancellationTokenSource.Token) is not User user || user.IsDeleted);
        }

        private static IEnumerable<Claim> ReadClaimsFromUser(User user)
        {

            yield return new Claim(JwtClaimTypes.Name, user.Name);
            yield return new Claim(JwtClaimTypes.Email, user.Email);
            yield return new Claim(JwtClaimTypes.Id, user.Id.ToString());
        }
    }
}
