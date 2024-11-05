using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Helpers;

public sealed class AuthTokenDriverHelper(ScenarioContext scenarioContext)
{
    public string GetToken()
    {
        var authTokenResponse = scenarioContext.GetAuthTokenResponse();
        return authTokenResponse.Token;
    }

    public string GetAuthErrorReason()
    {
        var authTokenResponse = scenarioContext.GetRestResponse();
        var token = authTokenResponse.Deserialize<AuthErrorResponse>();
        return token.Reason;
    }
}