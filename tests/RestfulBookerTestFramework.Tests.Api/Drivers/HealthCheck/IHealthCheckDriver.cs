namespace RestfulBookerTestFramework.Tests.Api.Drivers.HealthCheck;

public interface IHealthCheckDriver
{
    public Task ValidateHealthCheckBeforeScenarioRun();
}
