using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace IntegrationTests
{
    [TestFixture]
    public class PersonControllerSpecifications : TestBase
    {

        [Test, Category("Integration")]
        public async void Should_Allow_Admin_User_To_Create_Person()
        {
            ApiUsername = "bob";
            ApiPassword = "secret";

            var url = $"{HostServer}/api/v1.0/person/{TestUsers.First(x => x.FirstName == "Mary").Id}";
            var t = new HttpClient();
            var response = await AuthorizedHttpClient.PostAsJsonAsync(url, new
            {
                PersonId = TestUsers.First(x => x.FirstName == "Mary").Id,
                FirstName = TestUsers.First(x => x.FirstName == "Mary").FirstName,
                LastName = TestUsers.First(x => x.FirstName == "Mary").LastName,
                BirthDate = "1/1/2000"
            });

            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK &&  !content.Contains("FirstName\": \"Mary"))
                Assert.Fail("Should Have Returned (200) OK");
        }
    }
}
