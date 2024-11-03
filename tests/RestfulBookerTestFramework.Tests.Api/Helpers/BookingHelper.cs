using System.Linq;

using RestfulBookerTestFramework.Tests.Api.Drivers;
using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Factories;

namespace RestfulBookerTestFramework.Tests.Api.Helpers;

public class BookingHelper(ScenarioContext scenarioContext, EndpointsHelper endpointsHelper, IRequestDriver requestDriver)
{
    public void CreateBookings(int numberOfBookings)
    {
        var requestBookingBody = BookingFactory.GenerateBookings(numberOfBookings);

        string bookingEndpoint = endpointsHelper.GetBookingEndpoint();

        List<RestResponse> restResponsesList = new ();

        foreach (var bookingBody in requestBookingBody)
        {
            var response = requestDriver.SendPostRequest(bookingEndpoint, bookingBody);
            restResponsesList.Add(response);
        }
        
        scenarioContext.SetRestResponsesList(restResponsesList);
    }

    public int GetBookingId()
    {
        var bookingRequest = scenarioContext.GetRestResponsesList().First();
        var booking = JsonConvert.DeserializeObject<BookingResponse>(bookingRequest.Content);
        
        return booking.BookingId;
    }
}