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
    [ResourceAuthorize("Geek Foo")]
    [Time]
    [AutoInvalidateCacheOutput]
    [CacheOutput(ClientTimeSpan = Constants.CacheClientTimeSpan, ServerTimeSpan = Constants.CacheServerTimeSpan)]
    [System.Web.Http.RoutePrefix(Constants.Routes.EmailPrefix)]
    public class EmailController : ApiController
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The dal base
        /// </summary>
        protected readonly DalBase<Email> DalBase;

        public EmailController()
        {
            DalBase = new DalBase<Email>(new ApplicationContext());
        }

        [HttpGet, Route("", Name = Constants.RouteNames.GetEmailCollection)]
        public IHttpActionResult Get([FromUri] Guid personid)
        {
            try
            {
                Logger.Debug("Start Get Email Collection");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }

                if (person.EmailAddresses == null || !person.EmailAddresses.Any())
                {
                    Logger.Error("Email Addresses Not Found");
                    return NotFound();
                }

                return Ok(person.EmailAddresses.ToResources(Url, personid));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.GetEmailById)]
        public IHttpActionResult Get([FromUri] Guid personid, [FromUri] int id)
        {
            try
            {
                Logger.Debug("Start Get Email By Id");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }

                var persisted = person.EmailAddresses.FirstOrDefault(x => x.Id == id);

                if (persisted == null)
                {
                    Logger.Error("Email Not Found");
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

        [HttpPost, Route("", Name = Constants.RouteNames.CreateEmail)]
        public IHttpActionResult Post([FromUri] Guid personid, [FromBody]EmailResource email)
        {
            try
            {
                Logger.Debug("Start Create Person Email");

                // TODO: Validate entry!!!!
                // Recommend Fluent Validations - return BadRequest("With Reason");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }

                var entity = DalBase.Add(new Email
                {
                    Id = 0,
                    Address = email.Address,
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

        [HttpPut, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.EditEmail)]
        public IHttpActionResult Put([FromUri] Guid personid, int id, [FromBody]EmailResource email)
        {
            try
            {
                Logger.Debug("Start Update Person Email");

                // TODO: Validate entry!!!!
                // Recommend Fluent Validations - return BadRequest("With Reason");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }

                var persisted = person.EmailAddresses.FirstOrDefault(x => x.Id == id);

                if (persisted == null)
                {
                    Logger.Error("Email Not Found");
                    return NotFound();
                }

                persisted.Address = email.Address;

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

        [HttpDelete, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.DeleteEmail)]
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

                var persisted = person.EmailAddresses.FirstOrDefault(x => x.Id == id);

                if (persisted == null)
                {
                    Logger.Error("Email Not Found");
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
