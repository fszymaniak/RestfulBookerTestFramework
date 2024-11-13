﻿using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
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
    
    public void PatchUpdateBooking()
    {
        var bookingRequest = scenarioContext.GetBookingRequest();
        int bookingId = bookingHelper.GetBookingId();
        string bookingEndpoint = endpointsHelper.GetPatchBookingEndpoint(bookingId);
        
        var response = requestDriver.SendPatchRequest(bookingEndpoint, bookingRequest);
        scenarioContext.SetRestResponse(response);
    }
}