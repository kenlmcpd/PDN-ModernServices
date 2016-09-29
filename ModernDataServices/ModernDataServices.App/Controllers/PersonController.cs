using System;
using System.Net;
using System.Net.Http;
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
    /// The Person Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [ResourceAuthorize("Admin User")]
    [Time]
    [AutoInvalidateCacheOutput]
    [CacheOutput(ClientTimeSpan = Constants.CacheSettings.CacheClientTimeSpan, ServerTimeSpan = Constants.CacheSettings.CacheServerTimeSpan)]
    [System.Web.Http.RoutePrefix(Constants.Routes.PersonPrefix)]
    public class PersonController : ApiController
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The dal base
        /// </summary>
        protected readonly DalBase<Person> DalBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController"/> class.
        /// </summary>
        public PersonController()
        {
            DalBase = new DalBase<Person>(new ApplicationContext());
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Route(Constants.Routes.GuidIdRoute, Name = Constants.RouteNames.GetPersonById)]
        public IHttpActionResult Get([FromUri] Guid id)
        {
            try
            {
                Logger.Debug("Start Get Person");
                var person = DalBase.GetPersonWithChildren(x => x.PersonId == id);

                if (person == null)
                {
                    Logger.Error("Person Not Found");
                    return NotFound();
                }
                
                return Ok(person.ToResource(Url));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Posts the specified person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns></returns>
        [HttpPost, Route(Constants.Routes.GuidIdRoute, Name = Constants.RouteNames.CreatePerson)]
        public IHttpActionResult Post([FromUri] Guid id, [FromBody]PersonResource person)
        {
            try
            {
                // TODO: Validate entry!!!!
                // Recommend Fluent Validations - return BadRequest("With Reason");
                
                Logger.Debug("Start Create Person");

                var entity = DalBase.Add(new Person
                {
                    PersonId = id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthDate = person.BirthDate
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
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="person">The person.</param>
        /// <returns></returns>
        [HttpPut, Route(Constants.Routes.GuidIdRoute, Name = Constants.RouteNames.EditPerson)]
        public IHttpActionResult Put([FromUri] Guid id, [FromBody]PersonResource person)
        {
            try
            {
                // TODO: Validate entry!!!!
                // Recommend Fluent Validations - return BadRequest("With Reason");

                var entity = DalBase.First(x => x.PersonId == id);

                if (entity == null)
                {
                    Logger.Error("Person Not Found");
                    return NotFound();
                }

                entity.FirstName = person.FirstName;
                entity.LastName = person.LastName;
                entity.BirthDate = person.BirthDate;

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
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResourceAuthorize("Admin")]
        [HttpDelete, Route(Constants.Routes.GuidIdRoute, Name = Constants.RouteNames.DeletePerson)]
        public HttpResponseMessage Delete([FromUri] Guid id)
        {
            try
            {
                var entity = DalBase.First(x => x.PersonId == id);

                if (entity == null)
                {
                    Logger.Error("Person Not Found");
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                DalBase.Delete(entity);
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
