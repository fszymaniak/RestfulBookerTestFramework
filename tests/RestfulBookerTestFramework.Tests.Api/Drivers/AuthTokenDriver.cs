using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers
{
    internal class AuthTokenDriver(RestClient restClient, EndpointsHelper endpointsHelper, ScenarioContext scenarioContext)
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

            var response = SendPostRequestToAuthEndpoint(authEndpoint, requestAuthTokenBody);

            scenarioContext.SetRestResponse(response);
        }

        public void ValidateAuthTokenResponse()
        {
            var response = scenarioContext.GetRestResponse();
            var token = JsonConvert.DeserializeObject<AuthTokenResponse>(response.Content);

            token.Token.Should().NotBeNullOrEmpty();
        }

        private RestResponse SendPostRequestToAuthEndpoint(string authEndpoint, AuthTokenRequest requestAuthTokenBody)
        {
            var request = new RestRequest(authEndpoint, Method.Post);

            var cancellationTokenSource = new CancellationTokenSource();

            RestResponse response;
            request.AddBody(requestAuthTokenBody);

            try
            {
                response = restClient.ExecutePostAsync(request, cancellationTokenSource.Token).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return response;
        }
    }
}
