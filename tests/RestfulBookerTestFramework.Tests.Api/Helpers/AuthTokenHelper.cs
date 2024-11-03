using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Helpers;

public sealed class AuthTokenHelper(ScenarioContext scenarioContext)
{
    public string GetToken()
    {
        var authTokenResponse = scenarioContext.GetRestResponse();
        var token = JsonConvert.DeserializeObject<AuthTokenResponse>(authTokenResponse.Content);
        return token.Token;
    }

    public string GetAuthErrorReason()
    {
        var response = scenarioContext.GetRestResponse();
        var token = JsonConvert.DeserializeObject<AuthErrorResponse>(response.Content);
        return token.Reason;
    }
}