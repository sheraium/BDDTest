using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UserApi.Api.Controllers;
using UserApi.Entities;

namespace UserApi.Tests
{
    [Binding]
    public class UpdateUserFeatureSteps
    {
        ScenarioContext context = ScenarioContext.Current;

        [When(@"I request to update the user by Id with details")]
        public void WhenIRequestToUpdateTheUserByIdWithDetails(Table table)
        {
            var updateData = table.CreateInstance<UpdateUserDataTable>();
            var userController = context.Get<UsersController>();
            var response = userController.UpdateUser(1, updateData.Name, updateData.Surname, updateData.Email);
            context.Set(response);
        }

        [When(@"I request to update the user by Id with details Name: '(.*)' Surname: '(.*)' and Email: '(.*)'")]
        public void WhenIRequestToUpdateTheUserByIdWithDetailsNameSurnameAndEmail(string p0, string p1, string p2)
        {
            var usersController = context.Get<UsersController>();
            var response = usersController.UpdateUser(1, p0, p1, p2);
            context.Set(response);
        }

        [Then(@"the user should be updated")]
        public void ThenTheUserShouldBeUpdated()
        {
            var response = context.Get<IHttpActionResult>();
            var resp = response as OkResult;
            Assert.IsNotNull(resp);
        }
    }

    internal class UpdateUserDataTable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}