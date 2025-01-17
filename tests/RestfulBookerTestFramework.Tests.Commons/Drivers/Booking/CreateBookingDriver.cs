using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Drivers.Request;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Commons.Factories;
using RestfulBookerTestFramework.Tests.Commons.Helpers;

namespace RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

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

        response.SetBookingId(scenarioContext);
        scenarioContext.SetRestResponse(response);
        
    }
}
