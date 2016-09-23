namespace ModernDataServices.App
{
    /// <summary>
    /// A collection of constants that will be used in this project and any that reference it.
    /// </summary>
    public static class Constants
    {
        public static class AppInfo
        {
            public const string ApiVersion = "v1.0";

            public const string AppName = "MyApi";

            public const string AssemblyName = "ModernDataServices";

            public const string AssemblyHostName = "ModernDataServices.Api.Host";

            public const string DisplayName = "ModernDataServices.DisplayName";

            public const string ServiceName = "ModernDataServices.ServiceName";

            public const string Description = "Modern Data Service Description";
        }

        public static class HangfireInfo
        {
            public const string QueueName = "myqueue";
        }

        /// <summary>
        /// Api Routes - Constants
        /// </summary>
        public static class Routes
        {
            /// <summary>
            /// The API route prefix
            /// </summary>
            public const string ApiRoutePrefix = "api/" + AppInfo.ApiVersion;

            /// <summary>
            /// The person prefix
            /// </summary>
            public const string PersonPrefix = ApiRoutePrefix + "/person";

            /// <summary>
            /// The address prefix
            /// </summary>
            public const string AddressPrefix = ApiRoutePrefix + "/address";

            /// <summary>
            /// The phone prefix
            /// </summary>
            public const string PhonePrefix = ApiRoutePrefix + "/phone";

            /// <summary>
            /// The email prefix
            /// </summary>
            public const string EmailPrefix = ApiRoutePrefix + "/email";


            /// <summary>
            /// The version route
            /// </summary>
            public const string VersionRoute = "app/version";

            /// <summary>
            /// The uptime route
            /// </summary>
            public const string UptimeRoute = "app/uptime";

            /// <summary>
            /// The int identifier route
            /// </summary>
            public const string GuidIdRoute = "{id:Guid}";

            /// <summary>
            /// The int identifier route
            /// </summary>
            public const string IntIdRoute = "{id:int}";

            /// <summary>
            /// The get values route
            /// </summary>
            public const string GetValuesRoute = "values";

            /// <summary>
            /// The get secure values route
            /// </summary>
            public const string GetSecureValuesRoute = "values/secure";

            /// <summary>
            /// The get value by identifier route
            /// </summary>
            public const string GetValueByIdRoute = "values/{id:int}";


        }

        /// <summary>
        /// Api Route Names - Constants
        /// </summary>
        public static class RouteNames
        {
            /// <summary>
            /// The get uptime
            /// </summary>
            public const string GetUptime = "Get Up time";

            /// <summary>
            /// The get version
            /// </summary>
            public const string GetVersion = "Get Version";

            /// <summary>
            /// The get values
            /// </summary>
            public const string GetValues = "Get Values";

            /// <summary>
            /// The get secure values
            /// </summary>
            public const string GetSecureValues = "Get Secure Values";

            /// <summary>
            /// The get value by identifier
            /// </summary>
            public const string GetValueById = "Get Value By Id";

            public const string GetEmailCollection = "Get Emails";

            public const string GetEmailById = "Get Email By Id";

            public const string CreateEmail = "Create Email";
        }



        #region CacheOut Settings

        /// <summary>
        /// The cache server time span
        /// </summary>
        public const int CacheServerTimeSpan = 3600;

        /// <summary>
        /// The cache client time span
        /// </summary>
        public const int CacheClientTimeSpan = 3600;

        #endregion
    }
}
