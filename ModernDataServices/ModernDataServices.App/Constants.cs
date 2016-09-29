namespace ModernDataServices.App
{
    /// <summary>
    /// A collection of constants that will be used in this project and any that reference it.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Application Constants
        /// </summary>
        public static class AppInfo
        {
            /// <summary>
            /// The API version
            /// </summary>
            public const string ApiVersion           = "v1.0";

            /// <summary>
            /// The application name
            /// </summary>
            public const string AppName              = "MyApi";

            /// <summary>
            /// The assembly name
            /// </summary>
            public const string AssemblyName         = "ModernDataServices";

            /// <summary>
            /// The assembly host name/
            /// </summary>
            public const string AssemblyHostName     = "ModernDataServices.Api.Host";

            /// <summary>
            /// The display name
            /// </summary>
            public const string DisplayName          = "ModernDataServices.DisplayName";

            /// <summary>
            /// The service name
            /// </summary>
            public const string ServiceName          = "ModernDataServices.ServiceName";

            /// <summary>
            /// The description
            /// </summary>
            public const string Description          = "Modern Data Service Description";
        }

        /// <summary>
        /// Hangfire Constants
        /// </summary>
        public static class HangfireInfo
        {
            /// <summary>
            /// The Hangfire queue name
            /// </summary>
            public const string QueueName            = "myqueue";
        }

        /// <summary>
        /// Api Routes - Constants
        /// </summary>
        public static class Routes
        {
            /// <summary>
            /// The API route prefix
            /// </summary>
            public const string ApiRoutePrefix       = "api/" + AppInfo.ApiVersion;

            /// <summary>
            /// The person prefix
            /// </summary>
            public const string PersonPrefix         = ApiRoutePrefix + "/person";

            /// <summary>
            /// The address prefix
            /// </summary>
            public const string AddressPrefix        = ApiRoutePrefix + "/person/{personid:Guid}/address";

            /// <summary>
            /// The phone prefix
            /// </summary>
            public const string PhonePrefix          = ApiRoutePrefix + "/person/{personid:Guid}/phone";

            /// <summary>
            /// The email prefix
            /// </summary>
            public const string EmailPrefix          = ApiRoutePrefix + "/person/{personid:Guid}/email";


            /// <summary>
            /// The version route
            /// </summary>
            public const string VersionRoute         = "app/version";

            /// <summary>
            /// The uptime route
            /// </summary>
            public const string UptimeRoute          = "app/uptime";

            /// <summary>
            /// The int identifier route
            /// </summary>
            public const string GuidIdRoute          = "{id:Guid}";

            /// <summary>
            /// The int identifier route
            /// </summary>
            public const string IntIdRoute           = "{id:int}";

            /// <summary>
            /// The get values route
            /// </summary>
            public const string GetValuesRoute       = "values";

            /// <summary>
            /// The get secure values route
            /// </summary>
            public const string GetSecureValuesRoute = "values/secure";

            /// <summary>
            /// The get value by identifier route
            /// </summary>
            public const string GetValueByIdRoute    = "values/{id:int}";

            /// <summary>
            /// The email route
            /// </summary>
            public const string EmailRoute           = "/email";

            /// <summary>
            /// The address route
            /// </summary>
            public const string AddressRoute         = "/address";

            /// <summary>
            /// The phone route
            /// </summary>
            public const string PhoneRoute           = "/phone";

        }

        /// <summary>
        /// Api Route Names - Constants
        /// </summary>
        public static class RouteNames
        {
            /// <summary>
            /// The get uptime
            /// </summary>
            public const string GetUptime            = "Get Up time";

            /// <summary>
            /// The get version
            /// </summary>
            public const string GetVersion           = "Get Version";

            /// <summary>
            /// The get values
            /// </summary>
            public const string GetValues            = "Get Values";

            /// <summary>
            /// The get secure values
            /// </summary>
            public const string GetSecureValues      = "Get Secure Values";

            /// <summary>
            /// The get value by identifier
            /// </summary>
            public const string GetValueById         = "Get Value By Id";

            /// <summary>
            /// The get email collection
            /// </summary>
            public const string GetEmailCollection   = "Get Emails";

            /// <summary>
            /// The get email by identifier
            /// </summary>
            public const string GetEmailById         = "Get Email By Id";

            /// <summary>
            /// The create email
            /// </summary>
            public const string CreateEmail          = "Create Email";

            /// <summary>
            /// The edit email
            /// </summary>
            public const string EditEmail            = "Edit Email";

            /// <summary>
            /// The delete email
            /// </summary>
            public const string DeleteEmail          = "Delete Email";

            /// <summary>
            /// The get phone collection
            /// </summary>
            public const string GetPhoneCollection   = "Get Phones";

            /// <summary>
            /// The get phone by identifier
            /// </summary>
            public const string GetPhoneById         = "Get Phone By Id";

            /// <summary>
            /// The create phone
            /// </summary>
            public const string CreatePhone          = "Create Phone";

            /// <summary>
            /// The edit phone
            /// </summary>
            public const string EditPhone            = "Edit Phone";

            /// <summary>
            /// The delete phone
            /// </summary>
            public const string DeletePhone          = "Delete Phone";

            /// <summary>
            /// The get address collection
            /// </summary>
            public const string GetAddressCollection = "Get Addresss";

            /// <summary>
            /// The get address by identifier
            /// </summary>
            public const string GetAddressById       = "Get Address By Id";

            /// <summary>
            /// The create address
            /// </summary>
            public const string CreateAddress        = "Create Address";

            /// <summary>
            /// The edit address
            /// </summary>
            public const string EditAddress          = "Edit Address";

            /// <summary>
            /// The delete address/
            /// </summary>
            public const string DeleteAddress        = "Delete Address";

            /// <summary>
            /// The get person by identifier
            /// </summary>
            public const string GetPersonById        = "Get Person By Id";

            /// <summary>
            /// The create person/
            /// </summary>
            public const string CreatePerson         = "Create Person";

            /// <summary>
            /// The edit person
            /// </summary>
            public const string EditPerson           = "Edit Person";

            /// <summary>
            /// The delete person
            /// </summary>
            public const string DeletePerson         = "Delete Person";
        }

        public static class ResourseClaimsTypes
        {
            /// <summary>
            /// The user identifier
            /// </summary>
            public const string UserId               = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

            /// <summary>
            /// The roles
            /// </summary>
            public const string Roles                = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

            /// <summary>
            /// The name
            /// </summary>
            public const string Name                 = "name";

            /// <summary>
            /// The identifier
            /// </summary>
            public const string Id                   = "id";
        }

        public static class Roles
        {
            /// <summary>
            /// The admin
            /// </summary>
            public const string Admin                = "Admin";

            /// <summary>
            /// The user
            /// </summary>
            public const string User                 = "User";
        }

        public static class CacheSettings
        {
            /// <summary>
            /// The cache server time span
            /// </summary>
            public const int CacheServerTimeSpan     = 3600;

            /// <summary>
            /// The cache client time span
            /// </summary>
            public const int CacheClientTimeSpan     = 3600;
        }
    }
}
