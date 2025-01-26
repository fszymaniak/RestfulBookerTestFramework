using System;
using System.Net.Http;
using NBomber.Http.CSharp;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Commons.Helpers;

namespace RestfulBookerTestFramework.Tests.Performance.Helpers;

public class PerformanceHelper(EndpointsHelper endpointsHelper, BookingHelper bookingHelper) : IPerformanceHelper
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
            case Endpoints.BookingEndpointSingleId:
                return endpointsHelper.GetSingleBookingEndpoint(bookingHelper.GetBookingId());
            default:
                throw new ArgumentOutOfRangeException(endpointName, $"Invalid endpoint name: {endpointName}.");
        }
    }
}