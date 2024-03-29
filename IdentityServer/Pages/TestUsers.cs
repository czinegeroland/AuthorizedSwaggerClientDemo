using Duende.IdentityServer.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServerHost;

public class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "demo",
                    Password = "demo",
                    Claims =
                    {
                        new Claim("swagger_role", "DemoRole")
                    }
                },
            };
        }
    }
}