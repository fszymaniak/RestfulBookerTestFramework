namespace RestfulBookerTestFramework.Tests.Api.Extensions;

public static class RestRequestExtensions
{
    public static void WithAcceptHeader(this RestRequest request)
    {
        request.AddHeader("Accept", "application/json");
    }
    
    public static void WithContentTypeHeader(this RestRequest request)
    {
        request.AddHeader("Content-Type", "application/json");
    }

    public static void WithBodyParameter(this RestRequest request, object body)
    {
        request.AddParameter("application/json", body, ParameterType.RequestBody);
    }
    
    public static void WithCookieTokenHeader(this RestRequest request, string token)
    {
        request.AddHeader("Cookie", $"token={token}");
    }
    
    public static void AddAuthorization(this RestRequest request, Method method, ScenarioContext scenarioContext)
    {
        if (method is not (Method.Put or Method.Patch or Method.Delete))
        {
            return;
        }

        var token = scenarioContext.GetAuthTokenResponse();
        request.WithCookieTokenHeader(token.Token);
    }

    public static void AddBodyParameter(this RestRequest request, Method method,object body)
    {
        if (method is not (Method.Put or Method.Patch or Method.Post))
        {
            return;
        }

        request.WithContentTypeHeader();
        request.WithBodyParameter(body);
    }
}