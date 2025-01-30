using System.Text.Json;
using NBomber.Contracts;

namespace RestfulBookerTestFramework.Tests.Commons.Extensions;

public static class ResponseHttpResponseMessageExtenstion
{
    public static T Deserialize<T>(this Response<HttpResponseMessage> response)
    {
        return JsonSerializer.Deserialize<T>(response.Payload.Value.Content.ReadAsStringAsync().Result);
    }
}