using System;
using System.Net.Http;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Helpers;

namespace RestfulBookerTestFramework.Tests.Performance.StepDefinitions;

[Binding]
public class PerformanceSteps(EndpointsHelper endpointsHelper)
{
    private static readonly HttpClient HttpClient = new();
    
    [When("run inject performance scenario: '(.*)' for '(.*)' method and '(.*)' endpoint with Rate: (.*), Interval in seconds: (.*) and During in seconds: (.*)")]
    public void RunInjectPerformanceScenario(string scenarioName, string method, string endpoint, int rate, int interval, int during)
    {
        var scenario = Scenario.Create("http_scenario", async context =>
            {
                var request = CreatePerformanceRequest(method, endpoint);

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
                var request = CreatePerformanceRequest(method, endpoint);

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
                var request = CreatePerformanceRequest(method, endpoint);

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
    
    private HttpRequestMessage CreatePerformanceRequest(string method, string endpoint)
    {
        string url = GetEndpoint(endpoint, endpointsHelper);
        
        var request =               
            Http.CreateRequest(method, url)
                .WithHeader(RestRequestConstants.Headers.Accept, RestRequestConstants.Values.ApplicationJson);
        
        return request;
    }

    private static string GetEndpoint(string endpointName, EndpointsHelper endpointsHelper)
    {
        switch (endpointName)
        {
            case Endpoints.BookingEndpoint:
                return endpointsHelper.GetBookingEndpoint();
            default:
                throw new ArgumentOutOfRangeException(endpointName, $"Invalid endpoint name: {endpointName}.");
        }
    }
}
