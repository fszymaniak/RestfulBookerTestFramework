using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers
{
    public sealed class AuthTokenDriver(IRequestDriver requestDriver, EndpointsHelper endpointsHelper, ScenarioContext scenarioContext)
        : IAuthTokenDriver
    {
        public void CreateAuthTokenRequest(string userName, string password)
        {
            userName.Should().NotBeNullOrEmpty();
            password.Should().NotBeNullOrEmpty();

            var requestAuthTokenBody = new AuthTokenRequest
            {
                Username = userName,
                Password = password
            };

            scenarioContext.SetAuthTokenRequest(requestAuthTokenBody);
        }

        public void CreateAuthToken()
        {
            string authEndpoint = endpointsHelper.GetAuthEndpoint();

            var requestAuthTokenBody = scenarioContext.GetAuthTokenRequest();

            var response = requestDriver.SendPostRequest(authEndpoint, requestAuthTokenBody);

            scenarioContext.SetRestResponse(response);
        }

        public void ValidateAuthTokenResponse()
        {
            var response = scenarioContext.GetRestResponse();
            var token = JsonConvert.DeserializeObject<AuthTokenResponse>(response.Content);

            token.Token.Should().NotBeNullOrEmpty();
        }
        
        public void ValidateAuthErrorMessage()
        {
            var response = scenarioContext.GetRestResponse();
            var token = JsonConvert.DeserializeObject<AuthErrorResponse>(response.Content);

            token.Reason.Should().NotBeNullOrEmpty();
            token.Reason.Should().Be(ErrorMessages.AuthErrorMessage);
        }
    }
}
