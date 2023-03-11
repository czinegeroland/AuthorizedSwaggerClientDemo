using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace IdentityServerHost
{
    public static class Resources
    {
        public static IEnumerable<IdentityResource> Identity =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("DemoRole", "DemoRoleDisplayName", new[] { "swagger_role" })
            };

        public static IEnumerable<ApiScope> Apis =>
            new List<ApiScope>
            {
                new ApiScope("hangfireapi", "My Api")
            };
    }
}