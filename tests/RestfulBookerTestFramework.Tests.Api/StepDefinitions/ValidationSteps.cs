using RestfulBookerTestFramework.Tests.Commons.Drivers;
using RestfulBookerTestFramework.Tests.Commons.Drivers.Validation;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions
{
    [Binding]
    public sealed class ValidationSteps(IValidationDriver validationDriver)
    {
        [Then("status code should be '(.*)'")]
        public async Task ValidateStatusCode(HttpStatusCode expectedStatusCode)
        {
            await validationDriver.ValidateStatusCode(expectedStatusCode);
        }
        
        [Then("the newly created booking should be valid")]
        public void ThenTheCreatedBookingShouldBeValid()
        {
            validationDriver.ValidateCreatedBooking();
        }
        
        [Then("the newly '(.*)' updated booking should be valid")]
        public void ThenTheUpdatedBookingShouldBeValid(Method restRequestMethod)
        {
            validationDriver.ValidateUpdatedBooking(restRequestMethod);
        }
    }
}
