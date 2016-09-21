using System.Collections.Generic;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace ModernDataServices.App.Controllers
{
    [Authorize]
    [System.Web.Http.RoutePrefix(Constants.Routes.ApiRoutePrefix)]
    public class ValuesController : ApiController
    {
        // GET api/values
        [AllowAnonymous]
        [HttpGet, Route(Constants.Routes.GetValuesRoute, Name = Constants.RouteNames.GetValues)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet, Route(Constants.Routes.GetValueByIdRoute, Name = Constants.RouteNames.GetValueById)]
        public string Get(int id)
        {
            return "value";
        }

        //[ResourceAuthorize("Roles or Users")]
        [HttpGet, Route(Constants.Routes.GetSecureValuesRoute, Name = Constants.RouteNames.GetSecureValues)]
        public IEnumerable<string> GetSecureValues()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
