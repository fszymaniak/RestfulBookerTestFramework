namespace RestfulBookerTestFramework.Tests.Api.Drivers.AuthToken;

public interface IAuthTokenDriver
{
    public void CreateAuthTokenRequest(string userName, string password);

    public void CreateAuthToken();
    
    public void ValidateAuthTokenResponse();

    public void ValidateAuthErrorMessage();
}