using System.Net;
using FluentAssertions;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Drivers.Request;
using RestfulBookerTestFramework.Tests.Commons.DTOs.Models;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Commons.Helpers;

namespace RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

public sealed class DeleteBookingDriver(IRequestDriver requestDriver, ScenarioContext scenarioContext, EndpointsHelper endpointsHelper, IGetBookingDriver getBookingDriver) : IDeleteBookingDriver
{
    public async Task DeleteBookingAsync()
    {
        var expectedBookingResponse = scenarioContext.GetRestResponsesList().FirstOrDefault();
        var bookingId = expectedBookingResponse.Deserialize<BookingIdentifier>();
        scenarioContext.SetBookingId(bookingId.BookingId);
        
        string deleteBookingEndpoint = endpointsHelper.GetDeleteBookingEndpoint(bookingId.BookingId);
        
        var response = await requestDriver.SendDeleteRequestAsync(deleteBookingEndpoint);

        scenarioContext.SetRestResponse(response);
    }

    public async Task TryToDeleteNotExistingBookingAsync(int invalidBookingId = 0)
    {
        string deleteBookingEndpoint = endpointsHelper.GetDeleteBookingEndpoint(invalidBookingId);
        
        var response = await requestDriver.SendDeleteRequestAsync(deleteBookingEndpoint);

        scenarioContext.SetRestResponse(response);
    }

    public async Task ValidateIfBookingHasBeenDeleted()
    {
        var expectedBookingId = scenarioContext.GetBookingId();
        await getBookingDriver.GetSingleBooking(expectedBookingId);
        
        var actualRestResponse = scenarioContext.GetRestResponse();
        actualRestResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        actualRestResponse.Content.Should().NotBeNullOrEmpty();
        actualRestResponse.Content.Should().Be(ErrorMessages.NotFoundMessage);
    }
}
