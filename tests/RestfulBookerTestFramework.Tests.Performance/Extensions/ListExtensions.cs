using System.Collections.Generic;
using System.Net.Http;
using NBomber.Contracts;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Responses;
using RestSharp;

namespace RestfulBookerTestFramework.Tests.Performance.Extensions;

public static class ListExtensions
{
    public static void SetCreatedBookingIds(this List<int> bookingIdsList, string method, string endpoint,  Response<HttpResponseMessage> response, ScenarioContext scenarioContext)
    {
        var booking = response.Deserialize<BookingResponse>();
        
        if (method.Equals("POST") && endpoint.Equals(Endpoints.BookingEndpoint))
        {
            bookingIdsList.Add(booking.BookingId);
            scenarioContext.SetBookingIdsList(bookingIdsList);
        }
    }
}