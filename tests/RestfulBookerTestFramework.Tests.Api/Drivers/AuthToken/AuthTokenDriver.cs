using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.AuthToken
{
    public sealed class AuthTokenDriver(IRequestDriver requestDriver, EndpointsHelper endpointsHelper, ScenarioContext scenarioContext, AuthTokenDriverHelper authTokenDriverHelper)
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
            scenarioContext.SetAuthTokenResponse(response.Deserialize<AuthTokenResponse>());
        }
        
        public void ValidateAuthTokenResponse()
        {
            string token = authTokenDriverHelper.GetToken();
            token.Should().NotBeNullOrEmpty();
        }
        
        public void ValidateAuthErrorMessage()
        {
            var tokenErrorReason = authTokenDriverHelper.GetAuthErrorReason();

            tokenErrorReason.Should().NotBeNullOrEmpty();
            tokenErrorReason.Should().Be(ErrorMessages.AuthErrorMessage);
        }
    }
}
