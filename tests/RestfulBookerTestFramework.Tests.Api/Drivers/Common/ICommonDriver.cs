namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common
{
    public interface ICommonDriver
    {
        public void ValidateStatusCode(HttpStatusCode expectedStatusCode);
    }
}
