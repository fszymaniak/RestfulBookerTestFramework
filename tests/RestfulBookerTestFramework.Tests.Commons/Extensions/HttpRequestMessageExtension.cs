using NBomber.Http.CSharp;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.Extensions;

public static class HttpRequestMessageExtension
{
    public static HttpRequestMessage CreateRequest(string method, string url)
    {
        var request = Http.CreateRequest(method, url)
            .WithHeader(RestRequestConstants.Headers.Accept, RestRequestConstants.Values.ApplicationJson);
        
        return request;
    }
    
    public static void SetupRequestWithAuthorization(this HttpRequestMessage request, ScenarioContext scenarioContext)
    {
        request.WithAcceptHeader();
        request.AddAuthorization(scenarioContext);
    }
    
    private static void AddAuthorization(this HttpRequestMessage request, ScenarioContext scenarioContext)
    {
        var token = scenarioContext.GetAuthTokenResponse();
        request.WithCookieTokenHeader(token.Token);
    }
    
    private static void WithCookieTokenHeader(this HttpRequestMessage request, string token)
    {
        request.WithHeader(RestRequestConstants.Headers.Cookie, string.Format(RestRequestConstants.Values.TokenFormat, token));
    }
    
    private static void WithAcceptHeader(this HttpRequestMessage request)
    {
        request.WithHeader(RestRequestConstants.Headers.Accept, RestRequestConstants.Values.ApplicationJson);
    }
    
    
}