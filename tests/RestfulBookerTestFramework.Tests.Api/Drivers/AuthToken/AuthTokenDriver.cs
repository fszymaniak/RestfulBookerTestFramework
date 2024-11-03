using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.AuthToken
{
    public sealed class AuthTokenDriver(IRequestDriver requestDriver, EndpointsHelper endpointsHelper, ScenarioContext scenarioContext, AuthTokenHelper authTokenHelper)
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
            string token = authTokenHelper.GetToken();
            token.Should().NotBeNullOrEmpty();
        }
        
        public void ValidateAuthErrorMessage()
        {
            var tokenErrorReason = authTokenHelper.GetAuthErrorReason();

            tokenErrorReason.Should().NotBeNullOrEmpty();
            tokenErrorReason.Should().Be(ErrorMessages.AuthErrorMessage);
        }
    }
}
