using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Drivers
{
    public class CommonDriver(ScenarioContext scenarioContext) : ICommonDriver
    {
        public void ValidateStatusCode(HttpStatusCode expectedStatusCode)
        {
            var actualStatusCode = scenarioContext.GetRestResponse().StatusCode;
            actualStatusCode.Should().Be(expectedStatusCode);
        }
    }
}
