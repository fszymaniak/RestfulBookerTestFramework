using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.Extensions;

public static class RestRequestExtensions
{
    public static void SetupRequestWithAuthorizationAndBody(this RestRequest restRequest, object body, Method method,
        ScenarioContext scenarioContext)
    {
        restRequest.WithAcceptHeader();
        restRequest.AddAuthorization(method, scenarioContext);
        restRequest.AddBodyParameter(method, body);
    }
    
    private static void AddAuthorization(this RestRequest request, Method method, ScenarioContext scenarioContext)
    {
        if (method is not (Method.Put or Method.Patch or Method.Delete))
        {
            return;
        }

        var token = scenarioContext.GetAuthTokenResponse();
        request.WithCookieTokenHeader(token.Token);
    }

    private static void AddBodyParameter(this RestRequest request, Method method, object body)
    {
        if (method is not (Method.Put or Method.Patch or Method.Post))
        {
            return;
        }

        request.WithContentTypeHeader();
        request.WithBodyParameter(body);
    }
    
    private static void WithAcceptHeader(this RestRequest request)
    {
        request.AddHeader(RestRequestConstants.Headers.Accept, RestRequestConstants.Values.ApplicationJson);
    }
    
    private static void WithContentTypeHeader(this RestRequest request)
    {
        request.AddHeader(RestRequestConstants.Headers.ContentType, RestRequestConstants.Values.ApplicationJson);
    }

    private static void WithBodyParameter(this RestRequest request, object body)
    {
        request.AddParameter(RestRequestConstants.Values.ApplicationJson, body, ParameterType.RequestBody);
    }
    
    private static void WithCookieTokenHeader(this RestRequest request, string token)
    {
        request.AddHeader(RestRequestConstants.Headers.Cookie, string.Format(RestRequestConstants.Values.TokenFormat, token));
    }
}