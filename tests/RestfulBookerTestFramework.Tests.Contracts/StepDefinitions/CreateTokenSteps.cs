using RestfulBookerTestFramework.Tests.Commons.Configuration;
using RestfulBookerTestFramework.Tests.Commons.Drivers.AuthToken;

namespace RestfulBookerTestFramework.Tests.Contracts.StepDefinitions;

[Binding]
public sealed class CreateTokenSteps(IAuthTokenDriver authTokenDriver, AppSettings appSettings)
{
    [Given("a new valid auth token request is created")]
    public void CreateValidAuthTokenRequest()
    {
        authTokenDriver.CreateAuthTokenRequest(appSettings.Credentials.UserName, appSettings.Credentials.Password);
    }
    
    [StepDefinition("the new auth token is created")]
    public async Task CreateValidAuthTokenAsync()
    {
        await authTokenDriver.CreateAuthTokenAsync();
    }

    [Then("authorization token should be valid")]
    public async Task ValidateAuthResponse()
    {
        await authTokenDriver.ValidateAuthTokenResponse();
    }
}
