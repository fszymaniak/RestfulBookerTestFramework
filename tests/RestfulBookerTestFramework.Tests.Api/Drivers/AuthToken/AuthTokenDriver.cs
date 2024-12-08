using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.Helpers;
using RestfulBookerTestFramework.Tests.Commons.Drivers;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Requests;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Responses;

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

        public async Task CreateAuthTokenAsync()
        {
            string authEndpoint = endpointsHelper.GetAuthEndpoint();

            var requestAuthTokenBody = scenarioContext.GetAuthTokenRequest();

            var response = await requestDriver.SendPostRequestAsync(authEndpoint, requestAuthTokenBody);
            scenarioContext.SetRestResponse(response);
            scenarioContext.SetAuthTokenResponse(response.Deserialize<AuthTokenResponse>());
        }
        
        public Task ValidateAuthTokenResponse()
        {
            string token = authTokenDriverHelper.GetToken();
            token.Should().NotBeNullOrEmpty();
            
            return Task.CompletedTask;
        }
        
        public void ValidateAuthErrorMessage()
        {
            var tokenErrorReason = authTokenDriverHelper.GetAuthErrorReason();

            tokenErrorReason.Should().NotBeNullOrEmpty();
            tokenErrorReason.Should().Be(ErrorMessages.AuthErrorMessage);
        }
    }
}
