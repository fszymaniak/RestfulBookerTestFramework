using System;
using System.Net.Http;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Performance.Helpers;

namespace RestfulBookerTestFramework.Tests.Performance.StepDefinitions;

[Binding]
public class PerformanceRampingInjectLoadSimulationSteps(IPerformanceHelper performanceHelper)
{
    private static readonly HttpClient HttpClient = new();
    
    [When("run ramping inject performance scenario: '(.*)' for '(.*)' method and '(.*)' endpoint with Rate: (.*), Interval in seconds: (.*) and During in seconds: (.*)")]
    public void RunRampingInjectPerformanceScenario(string scenarioName, string method, string endpoint, int rate, int interval, int during)
    {
        var scenario = Scenario.Create(scenarioName, async context =>
            {
                var request = performanceHelper.CreatePerformanceRequest(method, endpoint);

                var response = await Http.Send(HttpClient, request);

                return response;
            })
            .WithoutWarmUp()
            .WithLoadSimulations(
                Simulation.RampingInject(rate: rate, 
                    interval: TimeSpan.FromSeconds(interval),
                    during: TimeSpan.FromSeconds(during))
            );

        NBomberRunner
            .RegisterScenarios(scenario)
            .Run();
    }
}
