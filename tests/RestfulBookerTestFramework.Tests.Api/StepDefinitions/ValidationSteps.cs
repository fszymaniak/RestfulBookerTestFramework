using RestfulBookerTestFramework.Tests.Api.Drivers.Common;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions
{
    [Binding]
    public sealed class ValidationSteps(IValidationDriver validationDriver)
    {
        [Then("status code should be '(.*)'")]
        public void ValidateStatusCode(HttpStatusCode expectedStatusCode)
        {
            validationDriver.ValidateStatusCode(expectedStatusCode);
        }
        
        [Then("the newly created booking should be valid")]
        public void ThenTheCreatedBookingShouldBeValid()
        {
            validationDriver.ValidateCreatedBooking();
        }
        
        [Then("the newly updated booking should be valid")]
        public void ThenTheUpdatedBookingShouldBeValid()
        {
            validationDriver.ValidateUpdatedBooking();
        }
    }
}
