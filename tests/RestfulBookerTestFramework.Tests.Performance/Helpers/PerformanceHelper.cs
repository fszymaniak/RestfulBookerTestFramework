using System;
using System.Net.Http;
using NBomber.Http.CSharp;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Commons.Helpers;
using SpecFlow.Internal.Json;

namespace RestfulBookerTestFramework.Tests.Performance.Helpers;

public class PerformanceHelper(EndpointsHelper endpointsHelper, BookingHelper bookingHelper, ScenarioContext scenarioContext) : IPerformanceHelper
{
    public HttpRequestMessage CreatePerformanceRequest(string method, string endpoint)
    {
        string url = GetEndpoint(endpoint);
        
        var request =               
            Http.CreateRequest(method, url)
                .WithHeader(RestRequestConstants.Headers.Accept, RestRequestConstants.Values.ApplicationJson);

        if (endpoint.Equals(Endpoints.AuthEndpoint))
        {
            request.WithJsonBody(scenarioContext.GetAuthTokenRequest());
        }
        
        return request;
    }

    private string GetEndpoint(string endpointName)
    {
        switch (endpointName)
        {
            case Endpoints.BookingEndpoint:
                return endpointsHelper.GetBookingEndpoint();
            case Endpoints.BookingEndpointSingleId:
                return endpointsHelper.GetSingleBookingEndpoint(bookingHelper.GetBookingId());
            case Endpoints.AuthEndpoint:
                return endpointsHelper.GetAuthEndpoint();
            default:
                throw new ArgumentOutOfRangeException(endpointName, $"Invalid endpoint name: {endpointName}.");
        }
    }
}