using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MethodTimer;
using ModernDataServices.App.Data;
using ModernDataServices.App.Models.Data;
using ModernDataServices.App.Models.Extensions;
using ModernDataServices.App.Models.Resources;
using NLog;
using Thinktecture.IdentityModel.WebApi;
using WebApi.OutputCache.V2;

namespace ModernDataServices.App.Controllers
{
    [ResourceAuthorize("Admin User")]
    [Time]
    [AutoInvalidateCacheOutput]
    [CacheOutput(ClientTimeSpan = Constants.CacheClientTimeSpan, ServerTimeSpan = Constants.CacheServerTimeSpan)]
    [System.Web.Http.RoutePrefix(Constants.Routes.AddressPrefix)]
    public class AddressController : ApiController
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The dal base
        /// </summary>
        protected readonly DalBase<Address> DalBase;

        public AddressController()
        {
            DalBase = new DalBase<Address>(new ApplicationContext());
        }

        [HttpGet, Route("", Name = Constants.RouteNames.GetAddressCollection)]
        public IHttpActionResult Get([FromUri] Guid personid)
        {
            try
            {
                Logger.Debug("Start Get Address Collection");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }
                
                if (person.Addresses == null || !person.Addresses.Any())
                {
                    Logger.Error("Addresses Not Found");
                    return NotFound();
                }
                
                return Ok(person.Addresses.ToResources(Url, personid));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.GetAddressById)]
        public IHttpActionResult Get([FromUri] Guid personid, [FromUri] int id)
        {
            try
            {
                Logger.Debug("Start Get Address By Id");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }
                
                var persisted = person.Addresses.FirstOrDefault(x => x.Id == id);

                if (persisted == null)
                {
                    Logger.Error("Address Not Found");
                    return NotFound();
                }

                return Ok(persisted.ToResource(Url));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("", Name = Constants.RouteNames.CreateAddress)]
        public IHttpActionResult Post([FromUri] Guid personid, [FromBody]AddressResource address)
        {
            try
            {
                Logger.Debug("Start Create Person Address");

                // TODO: Validate entry!!!!
                // Recommend Fluent Validations - return BadRequest("With Reason");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }
                
                var entity = DalBase.Add(new Address
                {
                    Id = 0,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    City = address.City,
                    State = address.State,
                    ZipCode = address.ZipCode,
                    Person = person
                });
                DalBase.SaveChanges();

                return Ok(entity.ToResource(Url));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.EditAddress)]
        public IHttpActionResult Put([FromUri] Guid personid, int id, [FromBody]AddressResource address)
        {
            try
            {
                Logger.Debug("Start Update Person Address");

                // TODO: Validate entry!!!!
                // Recommend Fluent Validations - return BadRequest("With Reason");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }

                var persisted = person.Addresses.FirstOrDefault(x => x.Id == id);

                if (persisted == null)
                {
                    Logger.Error("Address Not Found");
                    return NotFound();
                }

                persisted.Line1 = address.Line1;
                persisted.Line2 = address.Line2;
                persisted.City = address.City;
                persisted.State = address.State;
                persisted.ZipCode = address.ZipCode;

                DalBase.Update(persisted);
                DalBase.SaveChanges();

                return Ok(persisted.ToResource(Url));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.DeleteAddress)]
        public HttpResponseMessage Delete([FromUri] Guid personid, int id)
        {
            try
            {
                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                var persisted = person.Addresses.FirstOrDefault(x => x.Id == id);

                if (persisted == null)
                {
                    Logger.Error("Address Not Found");
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                DalBase.Delete(persisted);
                DalBase.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
