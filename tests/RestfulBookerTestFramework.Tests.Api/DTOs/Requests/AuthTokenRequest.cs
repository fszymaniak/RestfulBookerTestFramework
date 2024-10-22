using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Requests
{
    public class AuthTokenRequest
    {
        [JsonPropertyName(JsonPropertyNames.AuthorizationProperties.UserName)]
        public string Username { get; set; }

        [JsonPropertyName(JsonPropertyNames.AuthorizationProperties.Password)]
        public string Password { get; set; }
    }
}
