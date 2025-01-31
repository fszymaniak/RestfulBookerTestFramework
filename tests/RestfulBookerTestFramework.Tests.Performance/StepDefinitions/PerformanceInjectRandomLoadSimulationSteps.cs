﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Responses;
using RestfulBookerTestFramework.Tests.Performance.Helpers;

namespace RestfulBookerTestFramework.Tests.Performance.StepDefinitions;

[Binding]
public class PerformanceInjectRandomLoadSimulationSteps(IPerformanceHelper performanceHelper, ScenarioContext scenarioContext)
{
    private static readonly HttpClient HttpClient = new();
    private List<int> _bookingIdsList = new();
    
    [When("run inject random performance scenario: '(.*)' for '(.*)' method and '(.*)' endpoint with MinRate: (.*), MaxRate: (.*), Interval in seconds: (.*) and During in seconds: (.*)")]
    public void RunInjectRandomPerformanceScenario(string scenarioName, string method, string endpoint, int minRate, int maxRate, int interval, int during)
    {
        var scenario = Scenario.Create(scenarioName, async context =>
            {
                var request = performanceHelper.CreatePerformanceRequest(method, endpoint);

                var response = await Http.Send(HttpClient, request);
                
                var booking = response.Deserialize<BookingResponse>();
                
                if (method.Equals("POST") && endpoint.Equals(Endpoints.BookingEndpoint))
                {
                    _bookingIdsList.Add(booking.BookingId);
                    scenarioContext.SetBookingIdsList(_bookingIdsList);
                }

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
