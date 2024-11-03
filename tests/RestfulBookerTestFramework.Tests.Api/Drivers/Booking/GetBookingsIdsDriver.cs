using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public sealed class GetBookingsIdsDriver(IRequestDriver requestDriver, ScenarioContext scenarioContext, EndpointsHelper endpointsHelper) : IGetBookingsIdsDriver
{
    public void GetMultipleBookingsIds()
    {
        string bookingEndpoint = endpointsHelper.GetBookingEndpoint();
        
        var response = requestDriver.SendGetRequest(bookingEndpoint);

        scenarioContext.SetRestResponse(response);
    }
    
    public void GetMultipleBookingsIdsWithDateFilter()
    {
        string checkIn = DateHelper.GetCheckIn();
        string checkOut = DateHelper.GetCheckOut();
        
        string bookingEndpointWithDateFilter = endpointsHelper.GetBookingEndpointWithDateFilter(checkIn, checkOut);
        
        var response = requestDriver.SendGetRequest(bookingEndpointWithDateFilter);

        scenarioContext.SetRestResponse(response);
    }
    
    public void GetSingleBookingIdWithNameFilter()
    {
        var booking = scenarioContext.GetRestResponsesList()
            .Select(b => JsonConvert.DeserializeObject<BookingResponse>(b.Content)).First();
        
        scenarioContext.SetBookingRequest(booking);

        string bookingEndpointWithNameFilter = endpointsHelper.GetBookingEndpointWithNameFilter(booking.Booking.FirstName, booking.Booking.LastName);
        
        var response = requestDriver.SendGetRequest(bookingEndpointWithNameFilter);

        scenarioContext.SetRestResponse(response);
    }
    
    public void ValidateMultipleBookingsIds()
    {
        var actualRestResponse = scenarioContext.GetRestResponse();
        var actualBooking = JsonConvert.DeserializeObject<List<BookingIdentifier>>(actualRestResponse.Content);
        
        actualBooking.Count.Should().NotBe(0);
        actualBooking.Should().NotBeNullOrEmpty();
    }
    
    public void ValidateMultipleBookingsIdsFilteredByDate()
    {
        var expectedBookingIds = scenarioContext.GetRestResponsesList().SelectMany(r => JsonConvert.DeserializeObject<List<BookingIdentifier>>(r.Content));
        
        var actualRestResponse = scenarioContext.GetRestResponse();
        var actualBookingIds = JsonConvert.DeserializeObject<List<BookingIdentifier>>(actualRestResponse.Content);
        
        actualBookingIds.Count.Should().NotBe(0);
        actualBookingIds.Should().NotBeNullOrEmpty();
        actualBookingIds.Should().HaveCountGreaterOrEqualTo(actualBookingIds.Count);
        actualBookingIds.Should().Contain(expectedBookingIds);
    }
    
    public void ValidateSingleBookingIdFilteredByName()
    {
        var expectedBookingResponse = scenarioContext.GetRestResponsesList().FirstOrDefault();
        var expectedBookingId = JsonConvert.DeserializeObject<BookingIdentifier>(expectedBookingResponse.Content);
        
        var actualRestResponse = scenarioContext.GetRestResponse();
        var actualBookingIds = JsonConvert.DeserializeObject<List<BookingIdentifier>>(actualRestResponse.Content);
        
        actualBookingIds.Count.Should().NotBe(0);
        actualBookingIds.Should().NotBeNullOrEmpty();
        actualBookingIds.Should().ContainEquivalentOf(expectedBookingId);
    }
}