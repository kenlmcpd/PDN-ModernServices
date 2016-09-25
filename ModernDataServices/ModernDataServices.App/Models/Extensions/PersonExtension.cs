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
    public static class PersonExtension
    {
        public static PersonResource ToResource(this Person person, UrlHelper url)
        {
            LogManager.GetCurrentClassLogger().Debug("Start To Person Resource");
            return new PersonResource
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate,

                Addresses = person.Addresses.ToResources(url, person.PersonId),
                EmailAddresses = person.EmailAddresses.ToResources(url, person.PersonId),
                
                Phones = person.Phones.ToResources(url, person.PersonId),
                Links = new List<Link>
                {
                    new Link
                    {
                        Name = Constants.RouteNames.GetPersonById,
                        Method = "HttpGet",
                        Href = url.Link(Constants.RouteNames.GetPersonById, person.PersonId)
                    },
                    new Link
                    {
                        Name = Constants.RouteNames.EditPerson,
                        Method = "HttpPut",
                        Href = url.Link(Constants.RouteNames.EditPerson, person.PersonId)
                    },
                    new Link
                    {
                        Name = Constants.RouteNames.DeletePerson,
                        Method = "HttpDelete",
                        Href = url.Link(Constants.RouteNames.DeletePerson, person.PersonId)
                    },
                }
            };
        }
    }
}
