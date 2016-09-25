using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IntegrationTests
{
    public abstract class TestBase
    {
        protected TestBase()
        {
            HostServer = ConfigurationManager.AppSettings["HostServer"];
            ApiVersion = ConfigurationManager.AppSettings["ApiVersion"];
        }

        /// <summary>
        /// The host server
        /// </summary>
        protected string HostServer;
        /// <summary>
        /// The API version
        /// </summary>
        protected string ApiVersion;
        /// <summary>
        /// The etag
        /// </summary>
        protected string Etag;
        /// <summary>
        /// The API username
        /// </summary>
        protected string ApiUsername;
        /// <summary>
        /// The API password
        /// </summary>
        protected string ApiPassword;

        protected List<TestUser> TestUsers = new List<TestUser>
        {
            new TestUser {FirstName = "Bob", LastName = "Smith", Id = "fffbe7ab-7260-4cb3-af4a-4d86718e8bb6"},
            new TestUser {FirstName = "Mary", LastName = "Smith", Id = "cf5483c5-5c7d-497f-9899-ce403d411a88"},
            new TestUser {FirstName = "John", LastName = "Smith", Id = "cf5483c5-5c7d-497f-9899-ce403d411a89"},
            new TestUser {FirstName = "Sally", LastName = "Smith", Id = "cf5483c5-5c7d-497f-9899-ce403d411a90"},
            new TestUser {FirstName = "Ben", LastName = "Smith", Id = "cf5483c5-5c7d-497f-9899-ce403d411a91"}
        };


        protected HttpClient AuthorizedHttpClient
        {
            get { return GetHttpClient(ApiUsername, ApiPassword); }
        }

        protected HttpClient CachedHttpClient
        {
            get
            {
                return GetHttpClient(ConfigurationManager.AppSettings["IdentityUsername"],
                    ConfigurationManager.AppSettings["IdentityPassword"], true, true);
            }
        }

        protected HttpClient UnAuthorizedHttpClient
        {
            get { return GetHttpClient("bad", "pass", false); }
        }


        


        private HttpClient GetHttpClient(string username, string password, bool authorize = true, bool cache = false)
        {

            var client = new HttpClient {BaseAddress = new Uri(HostServer)};
            if (authorize)
            {
                var identitymodel = Authentication.IdentityModel(username, password);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(identitymodel.token_type,
                    identitymodel.access_token);
            }

            if (cache)
            {
                client.DefaultRequestHeaders.IfNoneMatch.Add(new EntityTagHeaderValue(Etag));
            }
            return client;
        }
    }

    public class Authentication
    {
        private static IdentityModel _idModel;



        public static IdentityModel IdentityModel(string username, string password)
        {
            return _idModel ?? (_idModel = Authenticate(username, password));
        }

        private static IdentityModel Authenticate(string username, string password)
        {
            var postData = string.Format("scope=webapi&username={0}&password={1}&grant_type=password", username, password);
            var byteArray = Encoding.UTF8.GetBytes(postData);

            var client = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["IdentityServerUrl"]) };
            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(ConfigurationManager.AppSettings["IdentityAppAuthorization"]);
            var response = client.PostAsync("", new ByteArrayContent(byteArray)).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IdentityModel>(content);
        }
    }

    public class IdentityModel
    {
        /// <summary>
        /// Gets or sets the access_token.
        /// </summary>
        /// <value>
        /// The access_token.
        /// </value>
        public string access_token { get; set; }
        /// <summary>
        /// Gets or sets the expires_in.
        /// </summary>
        /// <value>
        /// The expires_in.
        /// </value>
        public string expires_in { get; set; }
        /// <summary>
        /// Gets or sets the token_type.
        /// </summary>
        /// <value>
        /// The token_type.
        /// </value>
        public string token_type { get; set; }
    }

    public class TestUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
