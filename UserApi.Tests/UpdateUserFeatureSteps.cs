using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UserApi.Api.Controllers;

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
            userController.UpdateUser(1, updateData.Name, updateData.Surname, updateData.Email);

        }

        [When(@"I request to update the user by Id with details Name: '(.*)' Surname: '(.*)' and Email: '(.*)'")]
        public void WhenIRequestToUpdateTheUserByIdWithDetailsNameSurnameAndEmail(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the user should be updated")]
        public void ThenTheUserShouldBeUpdated()
        {
            ScenarioContext.Current.Pending();
        }
    }

    internal class UpdateUserDataTable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}