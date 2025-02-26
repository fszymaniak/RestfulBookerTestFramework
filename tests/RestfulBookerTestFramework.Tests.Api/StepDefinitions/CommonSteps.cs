﻿using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public class CommonSteps(IDeleteBookingDriver deleteBookingDriver, IGetBookingDriver getBookingDriver, IUpdateBookingDriver updateBookingDriver)
{
    [StepDefinition("trying to send '(.*)' method for not existing booking")]
    public async Task WhenTryingToUpdateBooking(Method requestMethod)
    {
        switch (requestMethod)
        {
            case Method.Delete:
                await deleteBookingDriver.TryToDeleteNotExistingBookingAsync();
                break;
            case Method.Get:
                await getBookingDriver.TryToGetNotExistingBookingAsync();
                break;
            case Method.Put:
                await updateBookingDriver.TryToPutUpdateNotExistingBookingAsync();
                break;
            case Method.Patch:
                await updateBookingDriver.TryToPatchUpdateNotExistingBookingAsync();
                break;
            default:
                throw new ArgumentOutOfRangeException(requestMethod.ToString(), $"Invalid update method {requestMethod}.");
        }
    }
}