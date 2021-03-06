﻿using BrockAllen.MembershipReboot.Owin;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using NLog;
using Owin;

namespace ModernDataServices.App.Config
{
    /// <summary>
    /// Own Hosting Configuration for the Service
    /// </summary>
    public class OwinHostedConfig
    {
        internal static OwinApplicationInformation AppInfo;
        private readonly bool _development;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwinHostedConfig"/> class.
        /// </summary>
        public OwinHostedConfig()
        {
            #if DEBUG
                _development = true;
            #endif
        }

        /// <summary>
        /// Configurations the application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Debug("Started  Config.Configuration");

            IocConfig.UseIoc();

            app.UseIdentityClientConfig();
            app.UseResourceAuthorization();

            app.UseHttpConfig();

            // Generic Home Page
            app.UseWelcomePage("/");

            // Non-Generic Home Page
            //app.UseFileServer(new FileServerOptions
            //{
            //    FileSystem = new PhysicalFileSystem(_development ? "../../content" : "content"),
            //    RequestPath = new PathString("")
            //});

            //app.UseWelcomePage("/content");

            app.UseMetrics();

            // Uncomment after you create the database
            //app.UseOwinHangfire();
        }
    }
}
