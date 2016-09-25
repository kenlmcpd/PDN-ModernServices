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
    /// <summary>
    /// Converts Address Entiy collection into Address Resource collection
    /// </summary>
    public static class AddressCollectionExtension
    {
        /// <summary>
        /// To the resources.
        /// </summary>
        /// <param name="addresses">The addresses.</param>
        /// <param name="url">The URL.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static CollectionResource<AddressResource> ToResources(this List<Address> addresses, UrlHelper url, Guid id)
        {
            LogManager.GetCurrentClassLogger().Debug("Start To Address Collection Resource");

            if(addresses == null)
            {
                addresses = new List<Address>();
            }

            var collection = new CollectionResource<AddressResource>
            {
                Collection = addresses.Select(x => x.ToResource(url)).ToList(),
                Links = new List<Link>
                {
                    new Link
                    {
                        Name = Constants.RouteNames.GetAddressCollection,
                        Method = "HttpGet",
                        Href = url.Link(Constants.RouteNames.GetAddressCollection, id) ?? $"{url.Request.RequestUri}{Constants.Routes.AddressRoute}"
                    },
                    new Link
                    {
                        Name = Constants.RouteNames.CreateAddress,
                        Method = "HttpPost",
                        Href = url.Link(Constants.RouteNames.CreateAddress, id) ?? $"{url.Request.RequestUri}{Constants.Routes.AddressRoute}"
                    }
                }
            };

            return collection;

        }
    }
}
