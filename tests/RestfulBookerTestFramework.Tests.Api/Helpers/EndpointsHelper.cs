using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.Helpers;

public sealed class EndpointsHelper
{
    private readonly AppSettings _appSettings;

    public EndpointsHelper(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    internal string GetAuthEndpoint()
    {
        return _appSettings.Urls.RestfulBookerUrl + Endpoints.AuthEndpoint;
    }
    
    internal string GetPingEndpoint()
    {
        return _appSettings.Urls.RestfulBookerUrl + Endpoints.HealthCheck;
    }
}