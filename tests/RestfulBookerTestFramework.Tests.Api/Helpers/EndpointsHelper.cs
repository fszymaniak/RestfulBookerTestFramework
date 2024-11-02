using System.Text.RegularExpressions;

using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.Helpers;

public sealed class EndpointsHelper
{
    private readonly AppSettings _appSettings;

    public EndpointsHelper(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    internal string GetAuthEndpoint()
    {
        return _appSettings.Urls.RestfulBookerUrl + Endpoints.AuthEndpoint;
    }
    
    internal string GetPingEndpoint()
    {
        return _appSettings.Urls.RestfulBookerUrl + Endpoints.HealthCheckEndpoint;
    }
    
    internal string GetBookingEndpoint()
    {
        return _appSettings.Urls.RestfulBookerUrl + Endpoints.BookingEndpoint;
    }
    
    internal string GetBookingEndpointWithDateFilter(string checkIn, string checkOut)
    {
        return _appSettings.Urls.RestfulBookerUrl + Endpoints.BookingEndpoint + $"?checkin={checkIn}&checkout={checkOut}";
    }
    
    internal string GetBookingEndpointWithNameFilter(string firstName, string lastName)
    {
        return _appSettings.Urls.RestfulBookerUrl + Endpoints.BookingEndpoint + $"?firstname={firstName}&lastname={lastName}";
    }
    
    internal string GetSingleBookingEndpoint(int bookingId)
    {
        return _appSettings.Urls.RestfulBookerUrl + Endpoints.BookingEndpoint + $"/{bookingId}";
    }

    internal int GetBookingIdFromResponseUri(string responseUri)
    {
        string id = Regex.Match(responseUri, @"\d+").Value;
        return int.Parse(id);
    }
}