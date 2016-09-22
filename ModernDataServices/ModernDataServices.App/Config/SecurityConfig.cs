using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using NLog;
using Owin;


namespace ModernDataServices.App.Config
{
    /// <summary>
    /// Registration Server (or other client) identity Configuration
    /// </summary>
    public static class SecurityConfig
    {
        /// <summary>
        /// Uses the resource authorization.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseResourceAuthorization(this IAppBuilder app)
        {
            app.UseResourceAuthorization(new ResourceAuthorization());
        }

        /// <summary>
        /// Sets the application to use the identity configuration.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseIdentityClientConfig(this IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = ConfigurationManager.AppSettings["Authority"],
                RequiredScopes = new[] { "sampleApi" },
                AuthenticationMode = AuthenticationMode.Active,
                ValidationMode = ValidationMode.Local,
                TokenProvider = new Provider()
            });
        }

        /// <summary>
        /// A class to add additional claims to the Identity.
        /// </summary>
        private class Provider : OAuthBearerAuthenticationProvider
        {
            /// <summary>
            /// Handles validating the identity produced from an OAuth bearer token.
            /// </summary>
            /// <param name="context">The identity context.</param>
            /// <returns>The task for asynchronous operations.</returns>
            public override Task ValidateIdentity(OAuthValidateIdentityContext context)
            {
                // Get Claims to find out if user actually is permitted to actual api
                // Then you can add an attribute over the api method to define what role
                // the user needs to that funtionality
                var claims = context.Ticket.Identity.Claims;

                
                return base.ValidateIdentity(context);
            }
        }

    }
}
