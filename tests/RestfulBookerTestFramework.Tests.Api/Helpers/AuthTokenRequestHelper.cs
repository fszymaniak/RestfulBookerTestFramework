using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Api.Drivers.AuthToken;

namespace RestfulBookerTestFramework.Tests.Api.Helpers;

public sealed class AuthTokenRequestHelper(IAuthTokenDriver authTokenDriver, AppSettings appSettings)
{
    public async Task AuthorizeRequestAsync()
    {
        authTokenDriver.CreateAuthTokenRequest(appSettings.Credentials.UserName, appSettings.Credentials.Password);
        await authTokenDriver.CreateAuthTokenAsync();
    }
}