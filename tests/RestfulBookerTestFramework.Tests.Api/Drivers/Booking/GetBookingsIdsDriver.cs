using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public sealed class GetBookingsIdsDriver(IRequestDriver requestDriver, ScenarioContext scenarioContext, EndpointsHelper endpointsHelper) : IGetBookingsIdsDriver
{
    public async Task GetMultipleBookingsIds()
    {
        string bookingEndpoint = endpointsHelper.GetBookingEndpoint();
        
        var response = await requestDriver.SendGetRequestAsync(bookingEndpoint);

        scenarioContext.SetRestResponse(response);
    }
    
    public async Task GetMultipleBookingsIdsWithDateFilter()
    {
        string checkIn = DateHelper.GetCheckIn();
        string checkOut = DateHelper.GetCheckOut();
        
        string bookingEndpointWithDateFilter = endpointsHelper.GetBookingEndpointWithDateFilter(checkIn, checkOut);
        
        var response = await requestDriver.SendGetRequestAsync(bookingEndpointWithDateFilter);

        scenarioContext.SetRestResponse(response);
    }
    
    public async Task GetSingleBookingIdWithNameFilter()
    {
        var booking = scenarioContext.GetRestResponsesList()
            .Select(b => b.Deserialize<BookingResponse>()).First();
        
        scenarioContext.SetBookingRequest(booking);

        string bookingEndpointWithNameFilter = endpointsHelper.GetBookingEndpointWithNameFilter(booking.Booking.FirstName, booking.Booking.LastName);
        
        var response = await requestDriver.SendGetRequestAsync(bookingEndpointWithNameFilter);

        scenarioContext.SetRestResponse(response);
    }
    
    public void ValidateMultipleBookingsIds()
    {
        var actualRestResponse = scenarioContext.GetRestResponse();
        var actualBooking = actualRestResponse.Deserialize<List<BookingIdentifier>>();
        
        actualBooking.Count.Should().NotBe(0);
        actualBooking.Should().NotBeNullOrEmpty();
    }
    
    public void ValidateMultipleBookingsIdsFilteredByDate()
    {
        var expectedBookingIds = scenarioContext.GetRestResponsesList().SelectMany(r => JsonConvert.DeserializeObject<List<BookingIdentifier>>(r.Content));
        
        var actualRestResponse = scenarioContext.GetRestResponse();
        var actualBookingIds = actualRestResponse.Deserialize<List<BookingIdentifier>>();
        
        actualBookingIds.Count.Should().NotBe(0);
        actualBookingIds.Should().NotBeNullOrEmpty();
        actualBookingIds.Should().HaveCountGreaterOrEqualTo(actualBookingIds.Count);
        actualBookingIds.Should().Contain(expectedBookingIds);
    }
    
    public void ValidateSingleBookingIdFilteredByName()
    {
        var expectedBookingResponse = scenarioContext.GetRestResponsesList().FirstOrDefault();
        var expectedBookingId = expectedBookingResponse.Deserialize<BookingIdentifier>();
        
        var actualRestResponse = scenarioContext.GetRestResponse();
        var actualBookingIds = actualRestResponse.Deserialize<List<BookingIdentifier>>();
        
        actualBookingIds.Count.Should().NotBe(0);
        actualBookingIds.Should().NotBeNullOrEmpty();
        actualBookingIds.Should().ContainEquivalentOf(expectedBookingId);
    }
}