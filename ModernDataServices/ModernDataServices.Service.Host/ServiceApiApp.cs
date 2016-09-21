using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin.Hosting;
using ModernDataServices.App.Config;
using NLog.Fluent;



namespace ModernDataServices.Service.Host
{
    public class ServiceApiApp
    {
        /// <summary>
        /// The owin web application
        /// </summary>
        protected IDisposable WebApplication;

        /// <summary>
        /// Start MemberApi Host Server
        /// </summary>
        public virtual void Start()
        {
            try
            {
                WebApplication = WebApp.Start<OwinHostedConfig>(ConfigurationManager.AppSettings["OwinUrl"]);
            }
            catch (Exception ex)
            {
                var error = ex;
                // If error = Access Denied
                //http://stackoverflow.com/questions/4019466/httplistener-access=denied
                //  netsh http add urlacl url="https://+:44319/" user=everyone
                throw;
            }
        }

        /// <summary>
        /// Method to stop the application.
        /// </summary>
        public virtual void Stop()
        {
            WebApplication.Dispose();
        }

        /// <summary>
        /// Method to pause the application.
        /// </summary>
        public virtual void Pause()
        {
            
        }

        /// <summary>
        /// Method to continue the application.
        /// </summary>
        public virtual void Continue()
        {

        }

        /// <summary>
        /// Method to shut down the application.
        /// </summary>
        public virtual void Shutdown()
        {

        }
    }
}
