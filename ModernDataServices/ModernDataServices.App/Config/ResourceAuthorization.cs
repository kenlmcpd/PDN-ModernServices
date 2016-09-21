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
            return context.Principal.Identity.IsAuthenticated ? Ok() : Nok();
        }
    }

}
