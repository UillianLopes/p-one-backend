using IdentityServer4.Models;
using System.Collections.Generic;

namespace POne.Identity.Api
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
           new IdentityResource[]
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
           };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("poneapi"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "http://localhost:4200",
                    ClientName = "POne Api",

                    AllowedGrantTypes = GrantTypes.Code,

                    AccessTokenType = AccessTokenType.Reference,

                    RequireClientSecret = false,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,

                    AllowedCorsOrigins = { "http://localhost:4200" },
                    AllowedScopes = { "openid", "profile", "poneapi" },
                    RedirectUris = { "http://localhost:4200/user/sign-in" },
                    PostLogoutRedirectUris = { "http://localhost:4200/user/sign-out" },
                },
            };
    }
}
