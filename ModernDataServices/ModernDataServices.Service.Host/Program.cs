using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernDataServices.App;
using NLog;
using Topshelf;

namespace ModernDataServices.Service.Host
{
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <returns></returns>
        private static int Main()
        {
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler);

            var config = System.Configuration.ConfigurationManager.AppSettings;
            var exitCode = HostFactory.Run(host =>
            {
                host.SetDescription(Constants.AppInfo.Description);
                host.SetDisplayName(Constants.AppInfo.DisplayName);
                host.SetServiceName(Constants.AppInfo.ServiceName);
                host.RunAs(config["DomainUser"], config["DomainPassword"]);
                host.StartAutomatically();
                
                host.BeforeInstall(() =>
                {
                    LogManager.GetCurrentClassLogger().Info("Beginning Install");
                });
                host.AfterInstall(() =>
                {
                    LogManager.GetCurrentClassLogger().Info("Completed Install");
                });
                host.BeforeRollback(() =>
                {
                    LogManager.GetCurrentClassLogger().Info("Beginning Rollback");
                });
                host.AfterRollback(() =>
                {
                    LogManager.GetCurrentClassLogger().Info("Completed Rollback");
                });
                host.BeforeUninstall(() =>
                {
                    LogManager.GetCurrentClassLogger().Info("Beginning Uninstall");
                });
                host.AfterUninstall(() => { LogManager.GetCurrentClassLogger().Info("Completed Uninstall"); });


                host.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1);
                    rc.RestartService(3);
                    rc.RestartService(5);
                });

                host.Service<ServiceApiApp>(service =>
                {
                    service.ConstructUsing(() => new ServiceApiApp());
                    service.WhenStarted(a => a.Start());
                    service.WhenStopped(a => a.Stop());
                    service.WhenPaused(s => s.Pause());
                    service.WhenContinued(s => s.Continue());
                    service.WhenShutdown(s => s.Shutdown());
                });
            });

            return (int)exitCode;
        }

        /// <summary>
        /// Exceptions the handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private static void ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            var e = args.ExceptionObject as Exception;
            var logger = LogManager.GetCurrentClassLogger();
            if (e == null)
            {
                logger.Error("This exception was not an exception");
            }
            else
            {
                logger.Error(e);
            }
        }
    }
}
