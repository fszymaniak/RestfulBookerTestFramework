﻿using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Hooks;

[Binding]
public class AfterScenarioHook(BookingHelper bookingHelper, ScenarioContext scenarioContext)
{
    [AfterScenario("CleanUpBooking")]
    public async Task AfterScenarioCleanUpBooking()
    {
        int bookingId = scenarioContext.GetBookingId();

        if (bookingId != 0)
        {
            await bookingHelper.CleanUpBookingAsync(bookingId);
        }
    }
    
    [AfterScenario("SetupMultipleBookings")]
    public async Task AfterScenarioCleanUpAllBookings()
    {
        var bookingsIds = bookingHelper.GetBookingsIds();

        foreach (var id in bookingsIds)
        {
            await bookingHelper.CleanUpBookingAsync(id);
        }
    }
}