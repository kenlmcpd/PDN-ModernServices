using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using NLog;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace ModernDataServices.App.Config
{
    internal class ResourceAuthorization : ResourceAuthorizationManager
    {
        /// <summary>
        /// Checks the access asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            //return context.Principal.Identity.IsAuthenticated ? Ok() : Nok();

            var logger = LogManager.GetCurrentClassLogger();
            logger.Trace("Started CheckAccessAsync");

            if (!context.Principal.Identity.IsAuthenticated)
            {
                logger.Trace("User Not Authenticated");
                return Nok();
            }

            try
            {
                var approvedroles = context.Action.First(x => x.Type == Constants.ResourseClaimsTypes.Name).Value;
                var userid = context.Principal.Claims.FirstOrDefault(x => x.Type == Constants.ResourseClaimsTypes.UserId);
                var id = context.Resource.FirstOrDefault(x => x.Type == Constants.ResourseClaimsTypes.Id);

                if (id == null || userid == null)
                {
                    return Nok();
                }


                if (approvedroles.Contains(Constants.Roles.Admin))
                {
                    logger.Trace("Admin updating Profile");
                    return Ok();
                }

                if (approvedroles.Contains(Constants.Roles.User) && id.Value == userid.Value)
                {
                    logger.Trace("User updating Own Profile");
                    return Ok();
                }

                logger.Trace("Cannot verify User Role");
                return  Nok();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }

}
