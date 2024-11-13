namespace RestfulBookerTestFramework.Tests.Api.Drivers.AuthToken;

public interface IAuthTokenDriver
{
    public void CreateAuthTokenRequest(string userName, string password);

    public Task CreateAuthTokenAsync();
    
    public Task ValidateAuthTokenResponse();

    public void ValidateAuthErrorMessage();
}