using System;
using System.Diagnostics;
using System.Web.Http;
using Newtonsoft.Json;

namespace ModernDataServices.App.Controllers
{
    /// <summary>
    /// Api Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController"/>
    [RoutePrefix(Constants.Routes.ApiRoutePrefix)]
    public class AppInfoController : ApiController
    {

        [AllowAnonymous]
        [HttpGet, Route(Constants.Routes.VersionRoute, Name = Constants.RouteNames.GetVersion)]
        public string Version()
        {
            return JsonConvert.SerializeObject(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }


        [AllowAnonymous]
        [HttpGet, Route(Constants.Routes.UptimeRoute, Name = Constants.RouteNames.GetUptime)]
        public string UpTime()
        {
            return JsonConvert.SerializeObject(DateTime.Now.Subtract(Process.GetCurrentProcess().StartTime));
        }

    }

}
