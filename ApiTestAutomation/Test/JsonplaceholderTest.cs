using System.Net;
using NUnit.Framework;
using TestAutomationFramework.Core;
using TestAutomationFramework.Helpers;

namespace TestAutomationFramework.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class JsonplaceholderTest
    {
        private readonly JsonPlaceholderClient jsonPlaceholderClient = new($"https://jsonplaceholder.typicode.com");

        [Test, Category("API")]
        public void VerifyThatUsersCanBeRetrieved()
        {
            Logger.LogInfo("Start API testing -- Retrieved all users");

            jsonPlaceholderClient.CreatedRequestAndSetResponse($"/users","GET");
            var users = jsonPlaceholderClient.GetUsersAsync();

            Assert.That(users.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            foreach (var user in users.Data) 
            {
                Assert.That(user.Id, Is.Not.Null.Or.Empty);
                Assert.That(user.Name, Is.Not.Null.Or.Empty);
                Assert.That(user.UserName, Is.Not.Null.Or.Empty);
                Assert.That(user.Email, Is.Not.Null.Or.Empty);
                Assert.That(user.Address, Is.Not.Null.Or.Empty);
                Assert.That(user.Phone, Is.Not.Null.Or.Empty);
                Assert.That(user.Website, Is.Not.Null.Or.Empty);
                Assert.That(user.Company, Is.Not.Null.Or.Empty);
            }

            Logger.LogInfo("End API testing -- Retrieved users");
        }

        [Test, Category("API")]
        public void VerifyThatHeaderExistOnResponse()
        {
            Logger.LogInfo("Start API testing -- Header exist");

            jsonPlaceholderClient.CreatedRequestAndSetResponse($"/users", "GET");
            var users = jsonPlaceholderClient.GetUsersAsync();

            Assert.That(users.ContentHeaders, Is.EqualTo("application/json; charset=utf-8"));
            Assert.That(users.ContentHeaders, Is.Not.Null.Or.Empty);
            Assert.That(users.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Logger.LogInfo("End API testing -- Header exist");
        }

        [Test, Category("API")]
        public void VerifyDataOnResponse()
        {
            Logger.LogInfo("Start API testing -- Data on response");

            jsonPlaceholderClient.CreatedRequestAndSetResponse($"/users", "GET");
            var users = jsonPlaceholderClient.GetUsersAsync();
            var ids = users.Data.Select(x => x.Id).ToList();

            Assert.That(users.Data.Count, Is.GreaterThan(0));
            Assert.That(ids.Count, Is.EqualTo(ids.Distinct().Count()));

            foreach (var user in users.Data)
            {
                Assert.That(user.Name, Is.Not.Null.Or.Empty);
                Assert.That(user.UserName, Is.Not.Null.Or.Empty);
                Assert.That(user.Company.Name, Is.Not.Null.Or.Empty);
            }

            Assert.That(users.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Logger.LogInfo("End API testing -- Data on response");
        }

        [Test, Category("API")]
        public void VerifyThatUserCanBeCreated()
        {
            Logger.LogInfo("Start API testing -- Created user");

            jsonPlaceholderClient.CreatedRequestAndSetResponse($"/users", "POST");
            var createUserResponse = jsonPlaceholderClient.CreateUserAsync();

            Assert.That(createUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(createUserResponse.User.Id, Is.Not.Null.Or.Empty);

            Logger.LogInfo("End API testing -- Created user");
        }

        [Test, Category("API")]
        public async Task VerifyThatResourceNotExist()
        {
            Logger.LogInfo("Start API testing -- Resource not found");

            jsonPlaceholderClient.CreatedRequestAndSetResponse($"/invalidendpoint", "GET");
            var users = await jsonPlaceholderClient.GetNotResourceAsync();

            Assert.That(users.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

            Logger.LogInfo("End API testing -- Resource not found");
        }
    }
}
