using System.Net;
using NUnit.Framework;
using RestfulBookerTestFramework.Tests.Commons.Drivers.Request;
using RestfulBookerTestFramework.Tests.Commons.Helpers;

namespace RestfulBookerTestFramework.Tests.Commons.Drivers.HealthCheck;

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