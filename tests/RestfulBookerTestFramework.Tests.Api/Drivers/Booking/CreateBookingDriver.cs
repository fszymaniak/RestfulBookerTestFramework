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
    
    public void GeneratePartiallyBookingWithSinglePropertyRequest(string partialBookingWithSinglePropertyRequest)
    {
        var requestBookingBody = PartiallyBookingSinglePropertyFactory.GeneratePartialBookingWithSingleProperties(partialBookingWithSinglePropertyRequest);

        scenarioContext.SetBookingRequest(requestBookingBody);
    }
    
    public void GeneratePartiallyBookingWithMultiplePropertiesRequest(string partialBookingWithMultiplePropertiesRequest)
    {
        var requestBookingBody = PartiallyBookingFactory.GeneratePartialBookingWithMultipleProperties(partialBookingWithMultiplePropertiesRequest);

        scenarioContext.SetBookingRequest(requestBookingBody);
    }

    public async Task CreateBooking()
    {
        string bookingEndpoint = endpointsHelper.GetBookingEndpoint();
        
        var bookingRequestBody = scenarioContext.GetBookingRequest();
        
        var response = await requestDriver.SendPostRequestAsync(bookingEndpoint, bookingRequestBody);
        
        scenarioContext.SetRestResponse(response);
    }
  
    
}