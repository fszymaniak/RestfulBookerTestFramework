using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.HealthCheck;

public sealed class HealthCheckDriver(IRequestDriver requestDriver, EndpointsHelper endpointsHelper) : IHealthCheckDriver
{
    public HttpStatusCode GetHealthCheckStatusCode()
    {
        var endpoint = endpointsHelper.GetPingEndpoint();
        var response = requestDriver.SendGetRequest(endpoint);
        return response.StatusCode;
    }
}