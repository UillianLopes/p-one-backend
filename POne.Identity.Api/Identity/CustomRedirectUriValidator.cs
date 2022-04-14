using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace POne.Identity.Api.Identity
{

    public class CustomRedirectUriValidator : IRedirectUriValidator
    {
        public Task<bool> IsPostLogoutRedirectUriValidAsync(string requestedUri, Client client)
        {
            if (client.PostLogoutRedirectUris == null)
                return Task.FromResult(true);

            var containsUri = client
                .PostLogoutRedirectUris
                .Any((uri) => uri.StartsWith(requestedUri));

            return Task.FromResult(containsUri);
        }

        public Task<bool> IsRedirectUriValidAsync(string requestedUri, Client client)
        {
            if (client.RedirectUris == null)
                return Task.FromResult(true);

            var containsUri = client
                .RedirectUris
                .Any((uri) => uri.StartsWith(requestedUri));

            return Task.FromResult(containsUri);
        }
    }

}
