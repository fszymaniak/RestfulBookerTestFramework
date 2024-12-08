using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Responses;

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