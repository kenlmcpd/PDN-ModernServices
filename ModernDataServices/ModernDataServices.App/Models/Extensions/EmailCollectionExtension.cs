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
    /// Converts Email Entiy collection into Email Resource collection
    /// </summary>
    public static class EmailCollectionExtension
    {
        /// <summary>
        /// To the Email Collection resources.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="url">The URL.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static CollectionResource<EmailResource> ToResources(this List<Email> email, UrlHelper url, Guid id)
        {
            LogManager.GetCurrentClassLogger().Debug("Start To Email Collection Resource");

            if (email == null)
            {
                email = new List<Email>();
            }
            
            var collection = new CollectionResource<EmailResource>
            {
                Collection = email.Select(x=> x.ToResource(url)).ToList(),
                Links = new List<Link>
                {
                    new Link
                    {
                        Name   = Constants.RouteNames.GetEmailCollection,
                        Method = "HttpGet",
                        Href   = url.Link(Constants.RouteNames.GetEmailCollection, id) ?? $"{url.Request.RequestUri}{Constants.Routes.EmailRoute}"
                    },
                    new Link
                    {
                        Name   = Constants.RouteNames.CreateEmail,
                        Method = "HttpPost",
                        Href   = url.Link(Constants.RouteNames.CreateEmail, id) ?? $"{url.Request.RequestUri}{Constants.Routes.EmailRoute}"
                    }
                }
            };

            return collection;

        }
    }
}
