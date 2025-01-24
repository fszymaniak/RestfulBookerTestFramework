using System;
using System.Net.Http;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Performance.Helpers;

namespace RestfulBookerTestFramework.Tests.Performance.StepDefinitions;

[Binding]
public class PerformanceSteps(IPerformanceHelper performanceHelper)
{
    private static readonly HttpClient HttpClient = new();
    
    [When("run inject performance scenario: '(.*)' for '(.*)' method and '(.*)' endpoint with Rate: (.*), Interval in seconds: (.*) and During in seconds: (.*)")]
    public void RunInjectPerformanceScenario(string scenarioName, string method, string endpoint, int rate, int interval, int during)
    {
        var scenario = Scenario.Create("http_scenario", async context =>
            {
                var request = performanceHelper.CreatePerformanceRequest(method, endpoint);

                var response = await Http.Send(HttpClient, request);

                return response;
            })
            .WithoutWarmUp()
            .WithLoadSimulations(
                Simulation.Inject(rate: rate, 
                    interval: TimeSpan.FromSeconds(interval),
                    during: TimeSpan.FromSeconds(during))
            );

        NBomberRunner
            .RegisterScenarios(scenario)
            .Run();
    }
    
    [When("run ramping inject performance scenario: '(.*)' for '(.*)' method and '(.*)' endpoint with Rate: (.*), Interval in seconds: (.*) and During in seconds: (.*)")]
    public void RunRampingInjectPerformanceScenario(string scenarioName, string method, string endpoint, int rate, int interval, int during)
    {
        var scenario = Scenario.Create("http_scenario", async context =>
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
    
    [When("run inject random performance scenario: '(.*)' for '(.*)' method and '(.*)' endpoint with MinRate: (.*), MaxRate: (.*), Interval in seconds: (.*) and During in seconds: (.*)")]
    public void RunInjectRandomPerformanceScenario(string scenarioName, string method, string endpoint, int minRate, int maxRate, int interval, int during)
    {
        var scenario = Scenario.Create("http_scenario", async context =>
            {
                var request = performanceHelper.CreatePerformanceRequest(method, endpoint);

                var response = await Http.Send(HttpClient, request);

                return response;
            })
            .WithoutWarmUp()
            .WithLoadSimulations(
                Simulation.InjectRandom(
                    minRate: minRate, 
                    maxRate: maxRate, 
                    interval: TimeSpan.FromSeconds(interval),
                    during: TimeSpan.FromSeconds(during))
            );

        NBomberRunner
            .RegisterScenarios(scenario)
            .Run();
    }
    
    
}
