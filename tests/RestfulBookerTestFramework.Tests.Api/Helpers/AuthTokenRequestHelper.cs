using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Api.Drivers.AuthToken;

namespace RestfulBookerTestFramework.Tests.Api.Helpers;

public sealed class AuthTokenRequestHelper(IAuthTokenDriver authTokenDriver, AppSettings appSettings)
{
    public void AuthorizeRequest()
    {
        authTokenDriver.CreateAuthTokenRequest(appSettings.Credentials.UserName, appSettings.Credentials.Password);
        authTokenDriver.CreateAuthToken();
    }
}