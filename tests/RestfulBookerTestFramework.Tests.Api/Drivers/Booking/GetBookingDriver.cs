﻿using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public sealed class GetBookingDriver(IRequestDriver requestDriver, ScenarioContext scenarioContext, EndpointsHelper endpointsHelper, BookingHelper bookingHelper) : IGetBookingDriver
{
    public async Task GetSingleBooking(int? bookingId = null)
    {
        bookingId ??= bookingHelper.GetBookingId();
        string bookingEndpoint = endpointsHelper.GetSingleBookingEndpoint(bookingId);
        
        var response = await requestDriver.SendGetRequestAsync(bookingEndpoint);

        scenarioContext.SetRestResponse(response);
    }
    
    public void ValidateGetSingleBooking()
    {
        var bookingResponse = scenarioContext.GetRestResponsesList().First();
        var expectedBooking = bookingResponse.Deserialize<BookingResponse>();

        var actualRestResponse = scenarioContext.GetRestResponse();
        var actualBooking = actualRestResponse.Deserialize<DTOs.Models.Booking>();
        int id = endpointsHelper.GetBookingIdFromResponseUri(actualRestResponse.ResponseUri.ToString());
        var actualBookingResponse = new BookingResponse
        {
            BookingId = id,
            Booking = actualBooking,
        };

        actualBookingResponse.BookingId.Should().BeOfType(typeof(int));
        actualBookingResponse.BookingId.Should().NotBe(0);
        actualBookingResponse.BookingId.Should().NotBe(null);
        actualBookingResponse.BookingId.Should().Be(expectedBooking.BookingId);
        actualBookingResponse.Should().BeEquivalentTo(expectedBooking);
    }

    public async Task TryToGetNotExistingBookingAsync(int invalidBookingId = 0)
    {
        string getBookingEndpoint = endpointsHelper.GetSingleBookingEndpoint(invalidBookingId);
        
        var response = await requestDriver.SendGetRequestAsync(getBookingEndpoint);

        scenarioContext.SetRestResponse(response);
    }
}
