using RestfulBookerTestFramework.Tests.Api.Drivers.HealthCheck;
using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common
{
    public sealed class CommonDriver(IHealthCheckDriver healthCheckDriver, ScenarioContext scenarioContext) : ICommonDriver
    {
        public void ValidateStatusCode(HttpStatusCode expectedStatusCode)
        {
            var actualStatusCode = scenarioContext.GetRestResponse().StatusCode;
            actualStatusCode.Should().Be(expectedStatusCode);
        }
        
        public void ValidateHealthCheckBeforeScenarioRun()
        {
            HttpStatusCode statusCode = healthCheckDriver.GetHealthCheckStatusCode();

            if (statusCode != HttpStatusCode.Created)
            { 
                Assert.Ignore($"This scenario is skipped due to the failed health check. Health Check status code: {statusCode}.");     
            }
        }
    }
}
