namespace RestfulBookerTestFramework.Tests.Api.Extensions;

public static class RestResponseExtensions
{
    public static T Deserialize<T>(this RestResponse response)
    {
        return JsonConvert.DeserializeObject<T>(response.Content);
    }
}