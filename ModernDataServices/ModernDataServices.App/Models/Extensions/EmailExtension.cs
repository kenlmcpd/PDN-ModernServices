using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using ModernDataServices.App.Models.Data;
using ModernDataServices.App.Models.Resources;
using NLog;

namespace ModernDataServices.App.Models.Extensions
{
    public static class EmailExtension
    {
        public static EmailResource ToResource(this Email email, UrlHelper url)
        {
            LogManager.GetCurrentClassLogger().Debug("Start To Email Resource");
            return new EmailResource
            {
                Id      = email.Id,
                Address = email.Address,
                Links   = new List<Link>
                {
                    new Link
                    {
                        Name   = Constants.RouteNames.GetEmailById,
                        Method = "HttpGet",
                        Href   = url.Link(Constants.RouteNames.GetEmailById, email.Id) ?? $"{url.Request.RequestUri}{Constants.Routes.EmailRoute}/{email.Id}"
                    },
                    new Link
                    {
                        Name   = Constants.RouteNames.EditEmail,
                        Method = "HttpPut",
                        Href   = url.Link(Constants.RouteNames.EditEmail, email.Id) ?? $"{url.Request.RequestUri}{Constants.Routes.EmailRoute}/{email.Id}"
                    },
                    new Link
                    {
                        Name   = Constants.RouteNames.DeleteEmail,
                        Method = "HttpDelete",
                        Href   = url.Link(Constants.RouteNames.DeleteEmail, email.Id) ?? $"{url.Request.RequestUri}{Constants.Routes.EmailRoute}/{email.Id}"
                    },
                }
            };
        }
    }
}
