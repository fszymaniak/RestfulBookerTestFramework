using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Api.Drivers.AuthToken;
using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Factories;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public sealed class CreateBookingDriver(IRequestDriver requestDriver, ScenarioContext scenarioContext, EndpointsHelper endpointsHelper) : ICreateBookingDriver
{
    public void GenerateBookingRequest()
    {
        var requestBookingBody = BookingFactory.GenerateBookings().FirstOrDefault();

        scenarioContext.SetBookingRequest(requestBookingBody);
    }
    
    public void GenerateInvalidBookingRequest(string invalidBookingRequest)
    {
        var requestBookingBody = PartiallyBookingFactory.GeneratePartialBookingWithMultipleProperties(invalidBookingRequest);

        scenarioContext.SetBookingRequest(requestBookingBody);
    }

    public void CreateBooking()
    {
        string bookingEndpoint = endpointsHelper.GetBookingEndpoint();

        var bookingRequestBody = scenarioContext.GetBookingRequest();

        var response = requestDriver.SendPostRequest(bookingEndpoint, bookingRequestBody);

        scenarioContext.SetRestResponse(response);
    }
  
    
}