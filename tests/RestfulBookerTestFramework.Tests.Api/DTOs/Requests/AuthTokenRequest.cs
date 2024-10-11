using System.Text.Json.Serialization;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Requests
{
    public class AuthTokenRequest
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
