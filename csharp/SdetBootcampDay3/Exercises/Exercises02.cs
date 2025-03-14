using System.Runtime;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace SdetBootcampDay3.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        private const string BASE_URL = "http://jsonplaceholder.typicode.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /**
         * TODO: rewrite these three tests into a single parameterized test
         * If you're stuck, have a look at the exercises for Day 1, as we
         * did the exact same thing there (just for a unit test instead of an API test).
         * Do this either using the [TestCase] attribute, or using [TestDataSource] combined
         * with the appropriate method to create and yield the TestCaseData objects.
         */
        /*[Test]
        public async Task GetDataForUser1_CheckName_ShouldEqualLeanneGraham()
        {
            RestRequest request = new RestRequest("/users/1", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo("Leanne Graham"));
        }

        [Test]
        public async Task GetDataForUser2_CheckName_ShouldEqualErvinHowell()
        {
            RestRequest request = new RestRequest("/users/2", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo("Ervin Howell"));
        }

        [Test]
        public async Task GetDataForUser3_CheckName_ShouldEqualClementineBauch()
        {
            RestRequest request = new RestRequest("/users/3", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo("Clementine Bauch"));
        }*/

        public static Dictionary<int, string> userIndexAndName = new Dictionary<int, string>()
        {
            {1, "Leanne Graham"},
            {2, "Ervin Howell"},
            {3, "Clementine Bauch"}
        };

        [Test, TestCaseSource("UserTestDataViaSource")]
        public async Task GetDataForUser_CheckName(int userIndex, string userName)
        {
            RestRequest request = new RestRequest($"/users/{userIndex}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo(userName));
        }

        private static IEnumerable<TestCaseData> UserTestDataViaSource()
        {
            for (int i = 1; i <= 3; i++)
            {
                yield return new TestCaseData(i, userIndexAndName[i]).SetName($"TestA: /users/{i} is {userIndexAndName[i]}");
            }
        }

        [TestCase(1, "Leanne Graham", TestName = "TestB: /users/1 is Leanne Graham")]
        [TestCase(2, "Ervin Howell", TestName = "TestB: /users/2 is Ervin Howell")]
        [TestCase(3, "Clementine Bauch", TestName = "TestB: /users/3 is Clementine Bauch")]
        public async Task UserTestData(int userIndex, string userName)
        {
            RestRequest request = new RestRequest($"/users/{userIndex}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo(userName));
        }
    }
}
