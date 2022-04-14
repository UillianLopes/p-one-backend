using IdentityModel.Client;
using IdentityServer4.Models;
using Microsoft.Extensions.Options;
using POne.Core.Options;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Api.Facades
{
    public class IdentityApiFacade
    {
        private readonly HttpClient _httpClient;

        private string AccessToken { get; set; }
        private DateTime? Expiration { get; set; }

        private bool IsAuthenticated
        {
            get => !string.IsNullOrEmpty(AccessToken) && Expiration != null && Expiration > DateTime.Now;
        }

        private string TokenEndpoint { get; set; }
        private readonly ApiEndpointOptions _options;


        public IdentityApiFacade(IHttpClientFactory factory, IOptions<ApiEndpointOptions> options)
        {
            _httpClient = factory.CreateClient("POne.Identity.Api.Client");
            _options = options.Value;
        }


        public async Task<string> GetTokenEndpointAsync(CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(TokenEndpoint))
                return TokenEndpoint;

            var discovery = await _httpClient.GetDiscoveryDocumentAsync(cancellationToken: cancellationToken);

            TokenEndpoint = discovery.TokenEndpoint;

            return TokenEndpoint;
        }
        public async Task<string> GetAccessTokenAsync(CancellationToken cancellationToken)
        {
            if (IsAuthenticated)
                return AccessToken;

            var authorizationEndpoint = await GetTokenEndpointAsync(cancellationToken);

            var authorizationResult = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                ClientSecret = "2452CAB2-E58A-44AE-BBC8-F92ACDDA3389",
                Scope = "ponenotifierapi",
                ClientId = "POne.Financial.Api",
                RequestUri = new Uri(authorizationEndpoint)

            }, cancellationToken);

            AccessToken = authorizationResult.AccessToken;
            Expiration = DateTime.Now.AddMinutes(authorizationResult.ExpiresIn);

            return authorizationResult.AccessToken;

        }

    }
}
