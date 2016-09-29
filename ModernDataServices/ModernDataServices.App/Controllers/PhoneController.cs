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
    /// <summary>
    /// The Phone Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [ResourceAuthorize("Admin User")]
    [Time]
    [AutoInvalidateCacheOutput]
    [CacheOutput(ClientTimeSpan = Constants.CacheSettings.CacheClientTimeSpan, ServerTimeSpan = Constants.CacheSettings.CacheServerTimeSpan)]
    [System.Web.Http.RoutePrefix(Constants.Routes.PhonePrefix)]
    public class PhoneController : ApiController
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The dal base
        /// </summary>
        protected readonly DalBase<Phone> DalBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneController"/> class.
        /// </summary>
        public PhoneController()
        {
            DalBase = new DalBase<Phone>(new ApplicationContext());
        }

        /// <summary>
        /// Gets the specified personid.
        /// </summary>
        /// <param name="personid">The personid.</param>
        /// <returns></returns>
        [HttpGet, Route("", Name = Constants.RouteNames.GetPhoneCollection)]
        public IHttpActionResult Get([FromUri] Guid personid)
        {
            try
            {
                Logger.Debug("Start Get Phone Collection");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }

                if (person.Phones == null || !person.Phones.Any())
                {
                    Logger.Error("Phonees Not Found");
                    return NotFound();
                }

                return Ok(person.Phones.ToResources(Url, personid));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the specified personid.
        /// </summary>
        /// <param name="personid">The personid.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.GetPhoneById)]
        public IHttpActionResult Get([FromUri] Guid personid, [FromUri] int id)
        {
            try
            {
                Logger.Debug("Start Get Phone By Id");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }

                var persisted = person.Phones.FirstOrDefault(x => x.Id == id);

                if (persisted == null)
                {
                    Logger.Error("Phone Not Found");
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

        /// <summary>
        /// Posts the specified personid.
        /// </summary>
        /// <param name="personid">The personid.</param>
        /// <param name="phone">The phone.</param>
        /// <returns></returns>
        [HttpPost, Route("", Name = Constants.RouteNames.CreatePhone)]
        public IHttpActionResult Post([FromUri] Guid personid, [FromBody]PhoneResource phone)
        {
            try
            {
                Logger.Debug("Start Create Person Phone");

                // TODO: Validate entry!!!!
                // Recommend Fluent Validations - return BadRequest("With Reason");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }

                var entity = DalBase.Add(new Phone
                {
                    Id = 0,
                    AreaCode = phone.AreaCode,
                    Number = phone.Number,
                    Extension = phone.Extension,
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

        /// <summary>
        /// Puts the specified personid.
        /// </summary>
        /// <param name="personid">The personid.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="phone">The phone.</param>
        /// <returns></returns>
        [HttpPut, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.EditPhone)]
        public IHttpActionResult Put([FromUri] Guid personid, int id, [FromBody]PhoneResource phone)
        {
            try
            {
                Logger.Debug("Start Update Person Phone");

                // TODO: Validate entry!!!!
                // Recommend Fluent Validations - return BadRequest("With Reason");

                var person = DalBase.GetPersonWithChildren(x => x.PersonId == personid);
                if (person == null)
                {
                    Logger.Error("Person Does not Exist");
                    return BadRequest("Person Does not Exist");
                }

                var persisted = person.Phones.FirstOrDefault(x => x.Id == id);

                if (persisted == null)
                {
                    Logger.Error("Phone Not Found");
                    return NotFound();
                }

                persisted.AreaCode = phone.AreaCode;
                persisted.Number = phone.Number;
                persisted.Extension = phone.Extension;
                
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

        /// <summary>
        /// Deletes the specified personid.
        /// </summary>
        /// <param name="personid">The personid.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.DeletePhone)]
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

                var persisted = person.Phones.FirstOrDefault(x => x.Id == id);

                if (persisted == null)
                {
                    Logger.Error("Phone Not Found");
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
