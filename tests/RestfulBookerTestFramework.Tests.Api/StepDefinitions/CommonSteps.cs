using RestfulBookerTestFramework.Tests.Api.Drivers.Common;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions
{
    [Binding]
    public sealed class CommonSteps(ICommonDriver commonDriver)
    {

        [Then("status code should be '(.*)'")]
        public void ValidateStatusCode(HttpStatusCode expectedStatusCode)
        {
            commonDriver.ValidateStatusCode(expectedStatusCode);
        }
    }
}
