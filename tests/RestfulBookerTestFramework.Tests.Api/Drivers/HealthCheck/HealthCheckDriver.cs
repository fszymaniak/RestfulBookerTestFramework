using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.HealthCheck;

public sealed class HealthCheckDriver(IRequestDriver requestDriver, EndpointsHelper endpointsHelper) : IHealthCheckDriver
{
    public async Task ValidateHealthCheckBeforeScenarioRun()
    {
        HttpStatusCode statusCode = await GetHealthCheckStatusCode();

        if (statusCode != HttpStatusCode.Created)
        { 
            Assert.Ignore($"This scenario is skipped due to the failed health check. Health Check status code: {statusCode}.");
        }
    }
    
    private async Task<HttpStatusCode> GetHealthCheckStatusCode()
    {
        var endpoint = endpointsHelper.GetPingEndpoint();
        var response = await requestDriver.SendGetRequestAsync(endpoint);
        return response.StatusCode;
    }
    
}