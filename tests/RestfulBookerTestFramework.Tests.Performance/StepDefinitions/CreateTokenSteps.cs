using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Configuration;
using RestfulBookerTestFramework.Tests.Commons.Drivers.AuthToken;

namespace RestfulBookerTestFramework.Tests.Performance.StepDefinitions;

[Binding]
public sealed class CreateTokenSteps(IAuthTokenDriver authTokenDriver, AppSettings appSettings)
{
    [Given("a new valid auth token request is created")]
    public void CreateValidAuthTokenRequest()
    {
        authTokenDriver.CreateAuthTokenRequest(appSettings.Credentials.UserName, appSettings.Credentials.Password);
    }
}
