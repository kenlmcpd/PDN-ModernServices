using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MethodTimer;
using ModernDataServices.App.Models.Resources;
using NLog;

namespace ModernDataServices.App.Controllers
{
    [Authorize]
    [Time]
    [System.Web.Http.RoutePrefix(Constants.Routes.PhonePrefix)]
    public class PhoneController : ApiController
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();


        
        public IHttpActionResult Get()
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

        
        public IHttpActionResult Get(int id)
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


        public IHttpActionResult Post([FromBody]PhoneResource phone)
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

        public IHttpActionResult Put(int id, [FromBody]PhoneResource phone)
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
