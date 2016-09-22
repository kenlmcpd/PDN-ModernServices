using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using IdentityModel.Client;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using ModernDataServices.App;
using Owin;
using ModernDataServices.App.Config;
using IdentityServer3.Core;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

[assembly: OwinStartup(typeof(ModernDataServices.MVC.Host.Startup))]

namespace ModernDataServices.MVC.Host
{
    /// <summary>
    /// MVC Owin Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            // Set up IOC Container
            IocConfig.UseIoc();

            // Set MVC to use the same Identity settings as Owin
            app.UseIdentityClientConfig();
            app.UseResourceAuthorization();

            // FUN Stuff
            app.UseMetrics();
            app.UseOwinHangfire();
            
         }
        }
}
