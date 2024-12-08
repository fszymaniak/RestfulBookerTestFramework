using RestfulBookerTestFramework.Tests.Commons.Drivers;

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
            switch (restRequestMethod)
            {
                case Method.Put:
                    validationDriver.ValidatePutUpdatedBooking();
                    break;
                case Method.Patch:
                    validationDriver.ValidatePatchUpdatedBooking();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(restRequestMethod), restRequestMethod, null);
            }
        }
    }
}
