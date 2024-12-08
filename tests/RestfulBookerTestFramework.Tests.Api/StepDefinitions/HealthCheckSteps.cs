using RestfulBookerTestFramework.Tests.Commons.Drivers.HealthCheck;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public class HealthCheckSteps(IHealthCheckDriver healthCheckDriver)
{
    [StepDefinition("Prerequisite: API is running")]
    public void ValidateIfApiIsRunning()
    {
        healthCheckDriver.ValidateHealthCheckBeforeScenarioRun();
    }
}