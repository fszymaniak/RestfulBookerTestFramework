using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Responses;

public sealed class AuthTokenResponse
{
    [JsonPropertyName(JsonPropertyNames.AuthorizationProperties.Token)]
    public string Token { get; set; }
}