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
    public static class AddressExtension
    {
        public static AddressResource ToResource(this Address address, UrlHelper url)
        {
           LogManager.GetCurrentClassLogger().Debug("Start To Address Resource");
            return new AddressResource
            {
                Id      = address.Id,
                Line1   = address.Line1,
                Line2   = address.Line2,
                City    = address.City,
                State   = address.State,
                ZipCode = address.ZipCode,
                Links   = new List<Link>
                {
                    new Link
                    {
                        Name   = Constants.RouteNames.GetAddressById,
                        Method = "HttpGet",
                        Href   = url.Link(Constants.RouteNames.GetAddressById, address.Id) ?? $"{url.Request.RequestUri}{Constants.Routes.AddressRoute}/{address.Id}"
                    },
                    new Link
                    {
                        Name   = Constants.RouteNames.EditAddress,
                        Method = "HttpPut",
                        Href   = url.Link(Constants.RouteNames.EditAddress, address.Id) ?? $"{url.Request.RequestUri}{Constants.Routes.AddressRoute}/{address.Id}"
                    },
                    new Link
                    {
                        Name   = Constants.RouteNames.DeleteAddress,
                        Method = "HttpDelete",
                        Href   = url.Link(Constants.RouteNames.DeleteAddress, address.Id) ?? $"{url.Request.RequestUri}{Constants.Routes.AddressRoute}/{address.Id}"
                    },
                }
            };
        }
    }
}
