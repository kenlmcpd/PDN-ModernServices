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
    [System.Web.Http.RoutePrefix(Constants.Routes.EmailPrefix)]
    public class EmailController : ApiController
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        
        [HttpGet, Route("", Name = Constants.RouteNames.GetEmailCollection)]
        public IHttpActionResult Get([FromUri] int userId)
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

        [HttpGet, Route(Constants.Routes.IntIdRoute, Name = Constants.RouteNames.GetEmailById)]
        public IHttpActionResult Get([FromUri] int userId, [FromUri] int id)
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

        [HttpPost, Route("", Name = Constants.RouteNames.CreateEmail)]
        public IHttpActionResult Post([FromBody]EmailResource email)
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

        public IHttpActionResult Put(int id, [FromBody]EmailResource email)
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

        public IHttpActionResult Delete(int id)
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
