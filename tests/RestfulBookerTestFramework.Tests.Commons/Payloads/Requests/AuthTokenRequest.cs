using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Requests
{
    public class AuthTokenRequest
    {
        [JsonPropertyName(JsonPropertyNames.AuthorizationProperties.UserName)]
        public string Username { get; set; }

        [JsonPropertyName(JsonPropertyNames.AuthorizationProperties.Password)]
        public string Password { get; set; }
    }
}
