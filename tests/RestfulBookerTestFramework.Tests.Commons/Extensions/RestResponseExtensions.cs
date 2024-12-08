using System.Text.Json;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Responses;
using RestSharp;

namespace RestfulBookerTestFramework.Tests.Commons.Extensions;

public static class RestResponseExtensions
{
    public static T Deserialize<T>(this RestResponse response)
    {
        return JsonSerializer.Deserialize<T>(response.Content);
    }

    public static void SetBookingId(this RestResponse response, ScenarioContext scenarioContext)
    {
        var bookingResponse = response.Deserialize<BookingResponse>();
        scenarioContext.SetBookingId(bookingResponse.BookingId);
    }
}