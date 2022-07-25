using IdentityModel;
using POne.Core.Contracts;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace POne.Api.Implementations
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        private readonly ClaimsPrincipal _principal;

        public AuthenticatedUser(IPrincipal principal) => _principal = (ClaimsPrincipal)principal;

        public Guid Id => Guid.TryParse(_principal.Claims.FirstOrDefault(e => e.Type == JwtClaimTypes.Id)?.Value, out Guid id) ? id : Guid.Empty;

        public Guid AccountId => Guid.TryParse(_principal.Claims.FirstOrDefault(e => e.Type == "AccountId")?.Value, out Guid id) ? id : Guid.Empty;

        public string Email => _principal.Claims.FirstOrDefault(e => e.Type == JwtClaimTypes.Email).Value;
    }
}
