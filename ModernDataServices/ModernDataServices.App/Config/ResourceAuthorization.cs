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
                // This is the string values from the attribute
                var approvedroles = context.Action.First(x => x.Type == Constants.ResourseClaimsTypes.Name).Value;

                // This is the controller and value being passed to the controller
                var id = context.Resource.FirstOrDefault(x => x.Type == Constants.ResourseClaimsTypes.Id);

                // The Claims as sent over from Identity Server
                var claims = context.Principal.Claims;

                // This is the User Guid from Identity Server
                var userid = claims.FirstOrDefault(x => x.Type == Constants.ResourseClaimsTypes.UserId);

                // The roles stored in the claim
                var roles = claims.Where(x => x.Type == Constants.ResourseClaimsTypes.Roles);

                // Something is wrong so kick the user out
                if (id == null || userid == null)
                {
                    return Nok();
                }

                // method or controller allows Admin and user has admin role
                if (approvedroles.Contains(Constants.Roles.Admin) && roles.Any(x => x.Value == "Admin") )
                {
                    logger.Trace("Admin updating Profile");
                    return Ok();
                }

                // method or controller allows User, User ID matches the request and User has user role
                if (approvedroles.Contains(Constants.Roles.User) && id.Value == userid.Value && roles.Any(x => x.Value == "User"))
                {
                    logger.Trace("User updating Own Profile");
                    return Ok();
                }

                // no match - keick the user out
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
