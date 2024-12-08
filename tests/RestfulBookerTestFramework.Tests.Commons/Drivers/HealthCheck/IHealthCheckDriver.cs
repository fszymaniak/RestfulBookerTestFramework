namespace RestfulBookerTestFramework.Tests.Commons.Drivers.HealthCheck;

public interface IHealthCheckDriver
{
    public Task ValidateHealthCheckBeforeScenarioRun();
}
