﻿using RestfulBookerTestFramework.Tests.Commons.Configuration;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Regex;

namespace RestfulBookerTestFramework.Tests.Commons.Helpers;

public sealed class EndpointsHelper(AppSettings appSettings)
{
    public string GetAuthEndpoint()
    {
        return appSettings.Urls.RestfulBookerUrl + Endpoints.AuthEndpoint;
    }
    
    internal string GetPingEndpoint()
    {
        return appSettings.Urls.RestfulBookerUrl + Endpoints.HealthCheckEndpoint;
    }
    
    public string GetBookingEndpoint()
    {
        return appSettings.Urls.RestfulBookerUrl + Endpoints.BookingEndpoint;
    }
    
    internal string GetBookingEndpointWithDateFilter(string checkIn, string checkOut)
    {
        return appSettings.Urls.RestfulBookerUrl + Endpoints.BookingEndpoint + $"?checkin={checkIn}&checkout={checkOut}";
    }
    
    internal string GetBookingEndpointWithNameFilter(string firstName, string lastName)
    {
        return appSettings.Urls.RestfulBookerUrl + Endpoints.BookingEndpoint + $"?firstname={firstName}&lastname={lastName}";
    }
    
    public string GetSingleBookingEndpoint(int? bookingId)
    {
        return GetEndpointWithBookingId(bookingId);
    }
    
    public string GetDeleteBookingEndpoint(int? bookingId)
    {
        return GetEndpointWithBookingId(bookingId);
    }
    
    internal string GetPutBookingEndpoint(int bookingId)
    {
        return GetEndpointWithBookingId(bookingId);
    }
    
    internal string GetPatchBookingEndpoint(int bookingId)
    {
        return GetEndpointWithBookingId(bookingId);
    }

    internal int GetBookingIdFromResponseUri(string responseUri) =>
        int.Parse(ResponseUriRegex.GetResponseUriRegex().Match(responseUri).Value);

    private string GetEndpointWithBookingId(int? bookingId) => appSettings.Urls.RestfulBookerUrl + Endpoints.BookingEndpoint + $"/{bookingId}";
}