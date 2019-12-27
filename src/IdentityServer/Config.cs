using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource("OrdersAPI", "My Orders API", new List<string> { JwtClaimTypes.Role })
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    
                    // scopes that client has access to
                    AllowedScopes = { "OrdersAPI" }
                },
                new Client
                {
                    ClientId = "UserNamePasswordClient",
                    
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },                   

                    // scopes that client has access to
                    AllowedScopes = { "OrdersAPI" }
                }

            };
        public static List<TestUser> TestUsers => new List<TestUser> {
            new TestUser
            {
                SubjectId = "123",
                Username = "administrator",
                Password = "123",
                Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Role, "admin"),
                    }
            }
        };
    }
}