namespace RestfulBookerTestFramework.Tests.Api.Drivers;

public interface IHealthCheckDriver
{
    public HttpStatusCode GetHealthCheckStatusCode();
}