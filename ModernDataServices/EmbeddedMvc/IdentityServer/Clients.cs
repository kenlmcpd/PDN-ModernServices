using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace EmbeddedMvc.IdentityServer
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client 
                {
                    ClientName = "MVC Client",
                    ClientId = "mvc",
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "https://localhost:44302/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44302/"
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "profile",
                        "roles",
                        "sampleApi"
                    }
                },
                new Client
                {
                    ClientName = "MVC Client (service communication)",   
                    ClientId = "mvc_service",
                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "sampleApi"
                    }
                },
                new Client()
                {
                    Enabled = true,
                    ClientName =  "OwinService",
                    ClientId = "OwinService",
                    Flow = Flows.ResourceOwner,
                    RequireConsent = false,
                    AccessTokenType = AccessTokenType.Jwt,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("somesecret".Sha256())
                    },
                    AllowAccessToAllCustomGrantTypes = true,
                    AllowAccessToAllScopes = true,
                },
                new Client()
                {
                    Enabled = true,
                    ClientName =  "Mvc Api",
                    ClientId = "MvcApi",
                    Flow = Flows.ResourceOwner,
                    RequireConsent = false,
                    AccessTokenType = AccessTokenType.Jwt,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("somesecret".Sha256())
                    },
                    AllowAccessToAllCustomGrantTypes = true,
                    AllowAccessToAllScopes = true,
                },
                
            };
        }
    }
}