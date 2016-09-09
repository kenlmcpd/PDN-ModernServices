using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire.Logging;
using Microsoft.Owin.Hosting;
using ModernDataServices.App.Config;
using NLog.Fluent;



namespace ModernDataServices.Service.Host
{
    public class ServiceApiApp
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        /// <summary>
        /// The owin web application
        /// </summary>
        protected IDisposable WebApplication;

        /// <summary>
        /// Start MemberApi Host Server
        /// </summary>
        public virtual void Start()
        {
            Log.Info("Starting ServiceApiApp.ApiHost");
            WebApplication = WebApp.Start<OwinHostedConfig>(ConfigurationManager.AppSettings["OwinUrl"]);
            Log.Info("ServiceApiApp.MemberApiServer Started");
        }

        /// <summary>
        /// Method to stop the application.
        /// </summary>
        public virtual void Stop()
        {
            WebApplication.Dispose();
            Log.Info("ServiceApiApp.MemberApiServer Stopped");
        }

        /// <summary>
        /// Method to pause the application.
        /// </summary>
        public virtual void Pause()
        {
            Log.Info("ServiceApiApp.MemberApiServer Paused");
        }

        /// <summary>
        /// Method to continue the application.
        /// </summary>
        public virtual void Continue()
        {
            Log.Info("ServiceApiApp.MemberApiServer Now Running");
        }

        /// <summary>
        /// Method to shut down the application.
        /// </summary>
        public virtual void Shutdown()
        {
            Log.Info("ServiceApiApp.MemberApiServer Shutdown Completed.");
        }
    }
}
