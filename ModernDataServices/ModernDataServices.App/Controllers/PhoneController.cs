using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MethodTimer;
using ModernDataServices.App.Models.Resources;
using NLog;
using Thinktecture.IdentityModel.WebApi;

namespace ModernDataServices.App.Controllers
{
    [ResourceAuthorize("Geek Foo")]
    [Time]
    [System.Web.Http.RoutePrefix(Constants.Routes.PhonePrefix)]
    public class PhoneController : ApiController
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();


        [HttpGet, Route("", Name = Constants.RouteNames.GetPhoneCollection)]
        public IHttpActionResult Get([FromUri] int personid)
        {
            try
            {

                return Ok();
            }
            catch (InvalidOperationException ioe)
            {
                Logger.Error(ioe);
                return BadRequest(ioe.Message);
            }
            catch (ArgumentNullException arngex)
            {
                Logger.Error(arngex);
                return BadRequest(arngex.Message);
            }
            catch (ArgumentException argex)
            {
                Logger.Error(argex);
                return BadRequest(argex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.GetPhoneById)]
        public IHttpActionResult Get([FromUri] int personid, [FromUri] int id)
        {
            try
            {

                return Ok();
            }
            catch (InvalidOperationException ioe)
            {
                Logger.Error(ioe);
                return BadRequest(ioe.Message);
            }
            catch (ArgumentNullException arngex)
            {
                Logger.Error(arngex);
                return BadRequest(arngex.Message);
            }
            catch (ArgumentException argex)
            {
                Logger.Error(argex);
                return BadRequest(argex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        //[ResourceAuthorize("Roles or Users")] // see public override Task ValidateIdentity(OAuthValidateIdentityContext context)

        [HttpPost, Route("", Name = Constants.RouteNames.CreatePhone)]
        public IHttpActionResult Post([FromUri] int personid, [FromBody]PhoneResource phone)
        {
            try
            {

                return Ok();
            }
            catch (InvalidOperationException ioe)
            {
                Logger.Error(ioe);
                return BadRequest(ioe.Message);
            }
            catch (ArgumentNullException arngex)
            {
                Logger.Error(arngex);
                return BadRequest(arngex.Message);
            }
            catch (ArgumentException argex)
            {
                Logger.Error(argex);
                return BadRequest(argex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.EditPhone)]
        public IHttpActionResult Put([FromUri] int personid, int id, [FromBody]PhoneResource phone)
        {
            try
            {

                return Ok();
            }
            catch (InvalidOperationException ioe)
            {
                Logger.Error(ioe);
                return BadRequest(ioe.Message);
            }
            catch (ArgumentNullException arngex)
            {
                Logger.Error(arngex);
                return BadRequest(arngex.Message);
            }
            catch (ArgumentException argex)
            {
                Logger.Error(argex);
                return BadRequest(argex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.DeletePhone)]
        public IHttpActionResult Delete([FromUri] int personid, int id)
        {
            try
            {

                return Ok();
            }
            catch (InvalidOperationException ioe)
            {
                Logger.Error(ioe);
                return BadRequest(ioe.Message);
            }
            catch (ArgumentNullException arngex)
            {
                Logger.Error(arngex);
                return BadRequest(arngex.Message);
            }
            catch (ArgumentException argex)
            {
                Logger.Error(argex);
                return BadRequest(argex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
