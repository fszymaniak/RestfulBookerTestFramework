using RestfulBookerTestFramework.Tests.Api.Drivers.HealthCheck;
using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common
{
    public sealed class CommonDriver(ScenarioContext scenarioContext) : ICommonDriver
    {
        public void ValidateStatusCode(HttpStatusCode expectedStatusCode)
        {
            var actualStatusCode = scenarioContext.GetRestResponse().StatusCode;
            actualStatusCode.Should().Be(expectedStatusCode);
        }
    }
}
