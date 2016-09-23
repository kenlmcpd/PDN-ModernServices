using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrics.Logging;
using Microsoft.Owin.Hosting;
using ModernDataServices.App.Config;
using NLog;


namespace ModernDataServices.Service.Host
{
    public class ServiceApiApp
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The owin web application
        /// </summary>
        protected IDisposable WebApplication;

        /// <summary>
        /// Start MemberApi Host Server
        /// </summary>
        public virtual void Start()
        {
            _logger.Info("Starting ModernDataServices.Service");
            WebApplication = WebApp.Start<OwinHostedConfig>(ConfigurationManager.AppSettings["OwinUrl"]);
            _logger.Info("ModernDataServices.Service Started");
        }

        /// <summary>
        /// Method to stop the application.
        /// </summary>
        public virtual void Stop()
        {
            WebApplication.Dispose();
            _logger.Info("ModernDataServices.Service Stopped");
        }

        /// <summary>
        /// Method to pause the application.
        /// </summary>
        public virtual void Pause()
        {
            _logger.Info("ModernDataServices.Service Paused");
        }

        /// <summary>
        /// Method to continue the application.
        /// </summary>
        public virtual void Continue()
        {
            _logger.Info("ModernDataServices.Service Now Running");
        }

        /// <summary>
        /// Method to shut down the application.
        /// </summary>
        public virtual void Shutdown()
        {
            _logger.Info("ModernDataServices.ServiceShutdown Completed.");
        }
    }
}
