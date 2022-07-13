using Duende.IdentityServer.Models;
using System.Collections.Generic;
using Duende.IdentityServer;

namespace IdentityServerHost
{
    public static class Clients
    {
        public static IEnumerable<Client> List =>
            new []
            {
                new Client
                {
                    ClientName ="demoName",
                    ClientId = "demo",
                    RequirePkce = true,
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    RequireClientSecret = true,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    RedirectUris = { "https://localhost:44393/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44393/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44393/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "DemoRole"
                    },
                },
            };
    }
}