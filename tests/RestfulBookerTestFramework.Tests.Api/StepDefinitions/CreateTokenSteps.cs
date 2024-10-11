using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Api.Drivers;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class CreateTokenSteps(IAuthTokenDriver authTokenDriver, AppSettings appSettings)
{
    [Given("a new valid auth token request is created")]
    public async Task CreateValidAuthTokenRequest()
    {
        authTokenDriver.CreateAuthTokenRequest(appSettings.Credentials.UserName, appSettings.Credentials.Password);
    }

    [StepDefinition("the new valid auth token is created")]
    public void CreateValidAuthTokenAsync()
    {
        authTokenDriver.CreateAuthToken();
    }

    [Then("authorization token should be valid")]
    public void ValidateAuthResponse()
    {
        authTokenDriver.ValidateAuthTokenResponse();
    }
}
