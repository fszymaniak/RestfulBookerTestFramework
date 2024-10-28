using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Api.Drivers;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class CreateTokenSteps(IAuthTokenDriver authTokenDriver, AppSettings appSettings)
{
    [Given("a new valid auth token request is created")]
    public void CreateValidAuthTokenRequest()
    {
        authTokenDriver.CreateAuthTokenRequest(appSettings.Credentials.UserName, appSettings.Credentials.Password);
    }
    
    [Given("an invalid auth token request with is following user name: '(.*)' and password: '(.*)' is created")]
    public void CreateValidAuthTokenRequest(string userName, string password)
    {
        userName = userName.ToLower() == "validuser" ? appSettings.Credentials.UserName : userName;
        password = password.ToLower() == "validpassword" ? appSettings.Credentials.Password : password;
        authTokenDriver.CreateAuthTokenRequest(userName, password);
    }

    [StepDefinition("the new auth token is created")]
    public void CreateValidAuthTokenAsync()
    {
        authTokenDriver.CreateAuthToken();
    }

    [Then("authorization token should be valid")]
    public void ValidateAuthResponse()
    {
        authTokenDriver.ValidateAuthTokenResponse();
    }
    
    [Then("bad credentials message should occur")]
    public void BadCredentialsMessageShouldOccur()
    {
        authTokenDriver.ValidateAuthErrorMessage();
    }
}