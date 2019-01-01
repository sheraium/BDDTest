using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Results;
using TechTalk.SpecFlow;
using UserApi.Api.Controllers;
using UserApi.Data.Repositories;
using UserApi.Entities;

namespace UserApi.Tests
{
    [Binding]
    public class GetUserFeatureSteps
    {
        private UsersController usersController;
        private IHttpActionResult response;

        [Given(@"that a user exists in the system")]
        public void GivenThatAUserExistsInTheSystem()
        {
            InMemoryUsersRepository repository = new InMemoryUsersRepository();
            Entities.User user = new User() { Id = 1, Email = "test@test.com", Name = "TestName", Surname = "TestSurnam" };
            repository.Add(user);
            usersController = new UsersController(repository);
        }

        [Given(@"that a user does not exist in the system")]
        public void GivenThatAUserDoesNotExistInTheSystem()
        {
            InMemoryUsersRepository repository = new InMemoryUsersRepository();
            usersController = new UsersController(repository);
        }

        [When(@"I request to get the user by Id")]
        public void WhenIRequestToGetTheUserById()
        {
            response = usersController.GetUser(1);
        }

        [Then(@"the user should be returned in the response")]
        public void ThenTheUserShouldBeReturnedInTheResponse()
        {
            var user = response as OkNegotiatedContentResult<User>;
            Assert.AreEqual(user.Content.Id, 1);
        }

        [Then(@"the response status code is ""(.*)""")]
        public void ThenTheResponseStatusCodeIs(string p0)
        {
            if (p0 == "200 OK")
            {
                var resp = response as OkNegotiatedContentResult<User>;
                Assert.IsNotNull(resp);
            }
            else if (p0 == "404 Not Found")
            {
                var resp = response as NotFoundResult;
                Assert.IsNotNull(resp);
            }
        }

        [Then(@"no user should be returned in the response")]
        public void ThenNoUserShouldBeReturnedInTheResponse()
        {
            var resp = response as NotFoundResult;
            Assert.IsNotNull(resp);
        }
    }
}