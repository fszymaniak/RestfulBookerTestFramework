using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Responses;

public sealed class AuthTokenResponse
{
    [JsonPropertyName(JsonPropertyNames.AuthorizationProperties.Token)]
    public string Token { get; set; }
}