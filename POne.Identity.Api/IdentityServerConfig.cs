using IdentityServer4.Models;
using System.Collections.Generic;
using System.Linq;

namespace POne.Identity.Api
{

    public class IdentityServerConfigClient
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string[] AllowedGrantTypes { get; set; }
        public string[] AllowedScopes { get; set; }
        public string[] AllowedCorsOrigins { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public string[] RedirectUris { get; set; }
        public string[] PostLogoutRedirectUris { get; set; }
        public bool RequirePkce { get; set; }
        public bool RequireClientSecret { get; set; }
        public string[] ClientSecrets { get; set; }
    }

    public class IdentityServerConfigApi
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string[] UserClaims { get; set; }
        public string[] Scopes { get; set; }
        public string[] ApiSecrets { get; set; }
    }

    public class IdentityServerConfig
    {
        public string IssuerUri { get; set; }
        public List<IdentityServerConfigClient> Clients { get; set; }
        public List<IdentityServerConfigApi> ApiResources { get; set; }
        public string[] ApiScopes { get; set; }

        public IEnumerable<ApiResource> GetApiResources() => ApiResources.Select(a => new ApiResource
        {
            Description = a.Description,
            Name = a.Name,
            DisplayName = a.DisplayName,
            UserClaims = a.UserClaims,
            Scopes = a.Scopes,
            ApiSecrets = a.ApiSecrets.Select(s => new Secret(s.Sha256())).ToList(),
        });

        public IEnumerable<IdentityResource> GetIdentityResources() =>
           new IdentityResource[]
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
           };

        public IEnumerable<ApiScope> GetApiScopes() => ApiScopes.Select(e => new ApiScope(e));

        public IEnumerable<Client> GetClients() => Clients.Select(c => new Client
        {
            ClientId = c.ClientId,
            ClientName = c.ClientName,
            AllowedGrantTypes = c.AllowedGrantTypes,
            AllowAccessTokensViaBrowser = c.AllowAccessTokensViaBrowser,
            AllowedCorsOrigins = c.AllowedCorsOrigins,
            AllowedScopes = c.AllowedScopes,
            RedirectUris = c.RedirectUris,
            PostLogoutRedirectUris = c.PostLogoutRedirectUris,
            RequirePkce = c.RequirePkce,
            RequireClientSecret = c.RequireClientSecret,
            ClientSecrets = c.ClientSecrets is string[] clientSecrets ? clientSecrets.Select((s) => new Secret(s.Sha256())).ToList() : null,
            AccessTokenLifetime = 10800,
        });


    }
}
