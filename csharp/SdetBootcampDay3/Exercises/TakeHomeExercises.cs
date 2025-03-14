using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using SdetBootcampDay3.Models;
using System.Net;

namespace SdetBootcampDay3.Exercises
{
    [TestFixture]
    public class TakeHomeExercises
    {
        /**
         * TODO: First, have a look at the API docs here: https://reqres.in
         */

        private const string BASE_URL = "https://reqres.in";

        private RestClient client;

        /**
         * TODO: Write a [OneTimeSetUp] method that initializes the RestClient before a test run
         */
        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /**
        * TODO: Write a test that creates a new request for an HTTP GET to "/api/users/2"
        * Send the request and check that the response status code is equal to HttpStatusCode.OK
        */
        [Test]
        public async Task GetUser2()
        {
            RestRequest request = new RestRequest("/api/users/2", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        /**
         * TODO: Write a parameterized test that retrieves data for users 1, 2 and 3 (see above for the
         * endpoint to use) and verify that their names are George, Janet and Emma, respectively.
         * You're looking for the "first_name" element that is a child element of the "data" element.
         * For an example, open https://reqres.in/api/users/1 in a browser.
         * You can decide for yourself whether to use [TestCase] or [TestCaseSource] (or both).
         */
        [TestCase(1, "George", TestName = "/api/users/1 is George")]
        [TestCase(2, "Janet", TestName = "/api/users/2 is Janet")]
        [TestCase(3, "Emma", TestName = "api/users/3 is Emma")]
        public async Task UserTestData(int userIndex, string userName)
        {
            RestRequest request = new RestRequest($"/api/users/{userIndex}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("data.first_name")!.ToString(), Is.EqualTo(userName));
        }

        /**
         * TODO: Write a new test that creates a new user using an HTTP POST.
         * Create the request body by instantiating and serializing an instance of the TakeHomeUserDto object.
         * Send the request and check that the response status code is equal to HttpStatusCode.Created.
         */
        [Test]
        public async Task PostTest()
        {
            TakeHomeUserDto newPost = new TakeHomeUserDto
            {
                Name = "Name",
                Job = "job"
            };

            RestRequest request = new RestRequest ("/api/create", Method.Post);

            request.AddJsonBody(newPost);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(201));
        }
    }
}
