using RestfulBookerTestFramework.Tests.Api.Drivers;

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

        [StepDefinition("Prerequisite: API is running")]
        public void ValidateIfApiIsRunning()
        {
            commonDriver.ValidateHealthCheckBeforeScenarioRun();
        }
    }
}
