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
    public static class PhoneExtension
    {
        public static PhoneResource ToResource(this Phone phone, UrlHelper url)
        {
            LogManager.GetCurrentClassLogger().Debug("Start To Phone Resource");
            return new PhoneResource
            {
                Id = phone.Id,
                AreaCode = phone.AreaCode,
                Number = phone.Number,
                Extension = phone.Extension,
                Links = new List<Link>
                {
                    new Link
                    {
                        Name = Constants.RouteNames.GetPhoneById,
                        Method = "HttpGet",
                        Href = url.Link(Constants.RouteNames.GetPhoneById, phone.Id) ?? $"{url.Request.RequestUri}{Constants.Routes.PhoneRoute}/{phone.Id}"
                    },
                    new Link
                    {
                        Name = Constants.RouteNames.EditPhone,
                        Method = "HttpPut",
                        Href = url.Link(Constants.RouteNames.EditPhone, phone.Id) ?? $"{url.Request.RequestUri}{Constants.Routes.PhoneRoute}/{phone.Id}"
                    },
                    new Link
                    {
                        Name = Constants.RouteNames.DeletePhone,
                        Method = "HttpDelete",
                        Href = url.Link(Constants.RouteNames.DeletePhone, phone.Id) ?? $"{url.Request.RequestUri}{Constants.Routes.PhoneRoute}/{phone.Id}"
                    },
                }
            };
        }
    }
}
