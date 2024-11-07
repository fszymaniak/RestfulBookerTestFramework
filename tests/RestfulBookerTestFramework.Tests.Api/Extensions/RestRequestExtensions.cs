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
}