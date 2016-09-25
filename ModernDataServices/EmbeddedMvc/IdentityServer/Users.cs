using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace EmbeddedMvc.IdentityServer
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "bob",
                    Password = "secret",
                    Subject = "fffbe7ab-7260-4cb3-af4a-4d86718e8bb6",                 
                    Enabled = true,
                    
                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Bob"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
                        new Claim(Constants.ClaimTypes.Role, "Admin"),
                        new Claim(Constants.ClaimTypes.Role, "User"),
                        new Claim(Constants.ClaimTypes.Role, "Login")
                    }
                },
                new InMemoryUser
                {
                    Username = "Mary",
                    Password = "secret",
                    Subject = "cf5483c5-5c7d-497f-9899-ce403d411a88",
                    Enabled = true,
                    
                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Dan"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
                        new Claim(Constants.ClaimTypes.Role, "User"),
                        new Claim(Constants.ClaimTypes.Role, "Login")
                    }
                },
                new InMemoryUser
                {
                    Username = "john",
                    Password = "secret",
                    Subject = "cf5483c5-5c7d-497f-9899-ce403d411a89",
                    Enabled = true,

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "John"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
                        new Claim(Constants.ClaimTypes.Role, "User"),
                        new Claim(Constants.ClaimTypes.Role, "Login")
                    }
                },
                new InMemoryUser
                {
                    Username = "sally",
                    Password = "secret",
                    Subject = "cf5483c5-5c7d-497f-9899-ce403d411a90",
                    Enabled = true,

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Sally"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
                        new Claim(Constants.ClaimTypes.Role, "User"),
                        new Claim(Constants.ClaimTypes.Role, "Login")
                    }
                },
                new InMemoryUser
                {
                    Username = "ben",
                    Password = "secret",
                    Subject = "cf5483c5-5c7d-497f-9899-ce403d411a91",
                    Enabled = true,

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Ben"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
                        new Claim(Constants.ClaimTypes.Role, "User"),
                        new Claim(Constants.ClaimTypes.Role, "Login")
                    }
                }
            };
        }
    }
}