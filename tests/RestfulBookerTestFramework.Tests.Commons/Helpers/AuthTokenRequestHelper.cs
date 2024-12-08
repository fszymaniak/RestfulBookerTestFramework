using RestfulBookerTestFramework.Tests.Commons.Configuration;
using RestfulBookerTestFramework.Tests.Commons.Drivers.AuthToken;

namespace RestfulBookerTestFramework.Tests.Commons.Helpers;

public sealed class AuthTokenRequestHelper(IAuthTokenDriver authTokenDriver, AppSettings appSettings)
{
    public async Task AuthorizeRequestAsync()
    {
        authTokenDriver.CreateAuthTokenRequest(appSettings.Credentials.UserName, appSettings.Credentials.Password);
        await authTokenDriver.CreateAuthTokenAsync();
    }
}