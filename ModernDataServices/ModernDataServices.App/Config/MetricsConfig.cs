﻿using System;
using System.Security.Cryptography.X509Certificates;
using Metrics;
using Owin;
using Owin.Metrics;
using WebApi.OutputCache.Core.Time;

namespace ModernDataServices.App.Config
{
    public static class MetricsConfig
    {
        /// <summary>
        /// Sets up the application to use the Metrics.NET library.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseMetrics(this IAppBuilder app)
        {
            Metric.Config
                .WithAppCounters("ModernDataServices.App")
                .WithInternalMetrics()
                .WithOwin(middleware => app.Use(middleware), config => config
                    .WithRequestMetricsConfig(c => c.WithAllOwinMetrics())
                    .WithMetricsEndpoint()
                );
        }
    }
}
