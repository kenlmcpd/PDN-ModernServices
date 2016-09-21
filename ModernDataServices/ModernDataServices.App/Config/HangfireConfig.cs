using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using Hangfire;
using Hangfire.Dashboard;
using Owin;
using StructureMap;

namespace ModernDataServices.App.Config
{
    /// <summary>
    /// A class to configure the background jobs.
    /// </summary>
    public static class HangfireConfig
    {

        /// <summary>
        /// Configures the application to utilize Hangfire for the Owin application
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="container">The container.</param>
        public static void UseOwinHangfire(this IAppBuilder app)
        {
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });

            GlobalConfiguration.Configuration
                .UseSqlServerStorage(
                ConfigurationManager.ConnectionStrings["HangfireDatabase"].ConnectionString);

            GlobalConfiguration.Configuration.UseActivator(new StructureMapActivator(IocConfig.Container));

            var options = new BackgroundJobServerOptions
            {
                Queues = new[] { Constants.HangfireInfo.QueueName },
            };

            app.UseHangfireServer(options);
            app.UseHangfireDashboard("/jobs", new DashboardOptions
            {
                AuthorizationFilters = new IAuthorizationFilter[]
                {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        LoginCaseSensitive = true,
                        RequireSsl = false,
                        SslRedirect = false,
                        Users = new[]
                        {
                            new BasicAuthAuthorizationUser
                            {
                                Login = "hangfireuser",
                                PasswordClear = "hangfire"
                            }
                        }
                    }),
                },
            });
            app.UseHangfireServer();

            // Add recurring jobs here
            //RecurringJob.AddOrUpdate("CleanLogs", () => Jobs.CleanLogData(), Cron.Monthly);

        }
    }

    /// <summary>
    /// A service locater for Hangfire, uses StructureMap as its IoC container. 
    /// </summary>
    public class StructureMapActivator : JobActivator
    {
        private readonly IContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="StructureMapActivator"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public StructureMapActivator(IContainer container)
        {
            this._container = container;
        }

        /// <summary>
        /// Activates the job.
        /// </summary>
        /// <param name="jobType">Type of the job.</param>
        /// <returns></returns>
        public override object ActivateJob(Type jobType)
        {
            return _container.GetInstance(jobType);
        }
    }
}
