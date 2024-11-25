using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public class UpdateBookingDriver(ScenarioContext scenarioContext, IRequestDriver requestDriver, BookingHelper bookingHelper, EndpointsHelper endpointsHelper) : IUpdateBookingDriver
{
    public async Task PutUpdateBookingAsync()
    {
        var bookingRequest = scenarioContext.GetBookingRequest();
        int bookingId = bookingHelper.GetBookingId();
        string bookingEndpoint = endpointsHelper.GetPutBookingEndpoint(bookingId);
        
        var response = await requestDriver.SendPutRequestAsync(bookingEndpoint, bookingRequest);
        scenarioContext.SetRestResponse(response);
    }
    
    public async Task PatchUpdateBooking()
    {
        var bookingRequest = scenarioContext.GetBookingRequest();
        int bookingId = bookingHelper.GetBookingId();
        string bookingEndpoint = endpointsHelper.GetPatchBookingEndpoint(bookingId);
        
        var response = await requestDriver.SendPatchRequestAsync(bookingEndpoint, bookingRequest);
        scenarioContext.SetRestResponse(response);
    }

    public async Task TryToPutUpdateNotExistingBookingAsync(int invalidBookingId = 0)
    {
        var bookingRequest = scenarioContext.GetBookingRequest();
        string putBookingEndpoint = endpointsHelper.GetPutBookingEndpoint(invalidBookingId);
        
        var response = await requestDriver.SendPutRequestAsync(putBookingEndpoint, bookingRequest);

        scenarioContext.SetRestResponse(response);
    }
    
    public async Task TryToPatchUpdateNotExistingBookingAsync(int invalidBookingId = 0)
    {
        var bookingRequest = scenarioContext.GetBookingRequest();
        string patchBookingEndpoint = endpointsHelper.GetPatchBookingEndpoint(invalidBookingId);
        
        var response = await requestDriver.SendPatchRequestAsync(patchBookingEndpoint, bookingRequest);

        scenarioContext.SetRestResponse(response);
    }
}