using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace ModernDataServices.App.Config
{
    /// <summary>
    /// A class to create new HTTP controllers through the IoC.
    /// </summary>
    public class ServiceActivator : IHttpControllerActivator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceActivator"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ServiceActivator(HttpConfiguration configuration)
        {

        }

        /// <summary>
        /// Creates an <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
        /// </summary>
        /// <param name="request">The message request.</param>
        /// <param name="controllerDescriptor">The HTTP controller descriptor.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>
        /// An <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
        /// </returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = IocConfig.Container.GetInstance(controllerType) as IHttpController;
            return controller;
        }
    }
}
