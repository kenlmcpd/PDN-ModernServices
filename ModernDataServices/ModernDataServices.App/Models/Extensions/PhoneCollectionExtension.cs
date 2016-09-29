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
    /// Converts Phone Entiy collection into Phone Resource collection
    /// </summary>
    public static class PhoneCollectionExtension
    {
        /// <summary>
        /// To the resources.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="url">The URL.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static CollectionResource<PhoneResource> ToResources(this List<Phone> phone, UrlHelper url, Guid id)
        {
            LogManager.GetCurrentClassLogger().Debug("Start To Phone Collection Resource");

            if (phone == null)
            {
                phone = new List<Phone>();
            }

            var collection = new CollectionResource<PhoneResource>
            {
                Collection = phone.Select(x => x.ToResource(url)).ToList(),
                Links = new List<Link>
                {
                    new Link
                    {
                        Name   = Constants.RouteNames.GetPhoneCollection,
                        Method = "HttpGet",
                        Href   = url.Link(Constants.RouteNames.GetPhoneCollection, id) ?? $"{url.Request.RequestUri}{Constants.Routes.PhoneRoute}"
                    },
                    new Link
                    {
                        Name   = Constants.RouteNames.CreatePhone,
                        Method = "HttpPost",
                        Href   = url.Link(Constants.RouteNames.CreatePhone, id) ?? $"{url.Request.RequestUri}{Constants.Routes.PhoneRoute}"
                    }
                }
            };

            return collection;

        }
    }
}
