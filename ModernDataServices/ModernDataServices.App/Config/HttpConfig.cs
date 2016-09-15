using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Security;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Tracing;
using System.Web.Mvc;
using Microsoft.Owin.Extensions;
using Owin;
using Swashbuckle.Application;
using WebApi.OutputCache.Core.Cache;
using WebApi.OutputCache.V2;

namespace ModernDataServices.App.Config
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpConfig
    {
        /// <summary>
        /// Uses the HTTP configuration.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseHttpConfig(this IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.EnableCors(new EnableCorsAttribute(origins: "*", headers: "*", methods: "* "));
            config.MapHttpAttributeRoutes();
            config.Services.Replace(typeof(IHttpControllerActivator), new ServiceActivator(config));
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.AddQueryStringMapping("format", "json", "application/json");
            config.Formatters.JsonFormatter.AddRequestHeaderMapping("ReturnType", "json", StringComparison.InvariantCultureIgnoreCase, false, "application/json");
            config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "application/xml");
            config.Formatters.XmlFormatter.AddQueryStringMapping("format", "xml", "application/xml");
            config.Formatters.XmlFormatter.AddRequestHeaderMapping("ReturnType", "xml", StringComparison.InvariantCultureIgnoreCase, false, "application/xml");
            config.EnsureInitialized();
            config.EnableSwagger(c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.SingleApiVersion(Constants.AppInfo.ApiVersion, Constants.AppInfo.AppName);
            })
                .EnableSwaggerUi(); 

            app.UseStageMarker(PipelineStage.MapHandler);

            config.CacheOutputConfiguration().RegisterCacheOutputProvider(() => new LoggingCacheOutputProviderDecorator(new MemoryCacheDefault()));
            
            app.UseWebApi(config);
        }
    }
 }
