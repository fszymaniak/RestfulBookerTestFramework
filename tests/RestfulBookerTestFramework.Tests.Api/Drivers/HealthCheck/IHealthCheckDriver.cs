namespace RestfulBookerTestFramework.Tests.Api.Drivers.HealthCheck;

public interface IHealthCheckDriver
{
    public HttpStatusCode GetHealthCheckStatusCode();
}
