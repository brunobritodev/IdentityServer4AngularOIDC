using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Server
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                // OpenID Connect implicit flow client (MVC
                new Client {
                    ClientId = "angularoidc",
                    ClientName = "Angular OpenId Connect",
                    //AccessTokenLifetime = 600, // 10 minutes, default 60 minutes
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    RedirectUris = { "http://localhost:4200/login-callback" },
                    PostLogoutRedirectUris =  { "http://localhost:4200/" },
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                    }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "bruno",
                    Password = "1234",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Bruno"),
                        new Claim(JwtClaimTypes.GivenName, "Bruno Brito"),
                        new Claim(JwtClaimTypes.FamilyName, "Brito"),
                        new Claim(JwtClaimTypes.Email, "bhdebrito@gmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://www.brunobrito.net.br"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'Av Paulista', 'locality': 'Sao Paulo', 'postal_code': 03323040, 'country': 'Brazil' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)

                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "jp",
                    Password = "1234",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "JP"),
                        new Claim(JwtClaimTypes.GivenName, "Joao Pedro"),
                        new Claim(JwtClaimTypes.FamilyName, "Silva"),
                        new Claim(JwtClaimTypes.Email, "jp@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://globo.com"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'Rua da Consolacao', 'locality': 'Sao Paulo', 'postal_code': 02565333, 'country': 'Brasil' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim("location", "Brazil")
                    }
                }
            };
        }
    }
}