using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public class UpdateBookingDriver(ScenarioContext scenarioContext, IRequestDriver requestDriver, BookingHelper bookingHelper, EndpointsHelper endpointsHelper) : IUpdateBookingDriver
{
    public void PutUpdateBooking()
    {
        var bookingRequest = scenarioContext.GetBookingRequest();
        int bookingId = bookingHelper.GetBookingId();
        string bookingEndpoint = endpointsHelper.GetPutBookingEndpoint(bookingId);
        
        var response = requestDriver.SendPutRequest(bookingEndpoint, bookingRequest);
        scenarioContext.SetRestResponse(response);
    }
}