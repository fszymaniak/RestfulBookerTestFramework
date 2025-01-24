using System;
using System.Net.Http;
using NBomber.Http.CSharp;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Helpers;

namespace RestfulBookerTestFramework.Tests.Performance.Helpers;

public class PerformanceHelper(EndpointsHelper endpointsHelper) : IPerformanceHelper
{
    public HttpRequestMessage CreatePerformanceRequest(string method, string endpoint)
    {
        string url = GetEndpoint(endpoint);
        
        var request =               
            Http.CreateRequest(method, url)
                .WithHeader(RestRequestConstants.Headers.Accept, RestRequestConstants.Values.ApplicationJson);
        
        return request;
    }

    private string GetEndpoint(string endpointName)
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