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
    
    [When("run performance scenario: '(.*)' for '(.*)' method and '(.*)' endpoint with Rate: (.*), Interval in seconds: (.*) and During in seconds: (.*)")]
    public void CreatePerformanceScenario(string scenarioName, string method, string endpoint, int rate, int interval, int during)
    {
        var scenario = Scenario.Create("http_scenario", async context =>
            {
                var request = CreatePerformanceRequest(method, endpoint);

                var response = await Http.Send(HttpClient, request);

                return response;
            })
            .WithoutWarmUp()
            .WithLoadSimulations(
                Simulation.Inject(rate: 5, 
                    interval: TimeSpan.FromSeconds(1),
                    during: TimeSpan.FromSeconds(5))
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
