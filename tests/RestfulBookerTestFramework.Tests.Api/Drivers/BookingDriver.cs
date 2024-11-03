using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Factories;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers;

public class BookingDriver(IRequestDriver requestDriver, ScenarioContext scenarioContext, EndpointsHelper endpointsHelper, BookingHelper bookingHelper, IAuthTokenDriver authTokenDriver, AppSettings appSettings) : IBookingDriver
{
    public void GenerateBookingRequest()
    {
        var requestBookingBody = BookingFactory.GenerateBookings().FirstOrDefault();

        scenarioContext.SetBookingRequest(requestBookingBody);
    }
    
    public void GenerateInvalidBookingRequest(string invalidBookingRequest)
    {
        var requestBookingBody = InvalidBookingFactory.GenerateInvalidBooking(invalidBookingRequest);

        scenarioContext.SetBookingRequest(requestBookingBody);
    }

    public void CreateBooking()
    {
        string bookingEndpoint = endpointsHelper.GetBookingEndpoint();

        var bookingRequestBody = scenarioContext.GetBookingRequest();

        var response = requestDriver.SendPostRequest(bookingEndpoint, bookingRequestBody);

        scenarioContext.SetRestResponse(response);
    }

    public void GetSingleBooking(int? bookingId = null)
    {
        bookingId ??= bookingHelper.GetBookingId();
        string bookingEndpoint = endpointsHelper.GetSingleBookingEndpoint(bookingId);
        
        var response = requestDriver.SendGetRequest(bookingEndpoint);

        scenarioContext.SetRestResponse(response);
    }

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

    public void DeleteBooking()
    {
        var expectedBookingResponse = scenarioContext.GetRestResponsesList().FirstOrDefault();
        var bookingId = JsonConvert.DeserializeObject<BookingIdentifier>(expectedBookingResponse.Content);
        scenarioContext.SetBookingId(bookingId.BookingId);
        authTokenDriver.CreateAuthTokenRequest(appSettings.Credentials.UserName, appSettings.Credentials.Password);
        authTokenDriver.CreateAuthToken();
        
        string deleteBookingEndpoint = endpointsHelper.GetDeleteBookingEndpoint(bookingId.BookingId);
        
        var response = requestDriver.SendDeleteRequest(deleteBookingEndpoint);

        scenarioContext.SetRestResponse(response);
    }

    public void ValidateCreatedBooking()
    {
        var expectedBooking = scenarioContext.GetBookingRequest();
        
        var actualBookingResponse = scenarioContext.GetRestResponse();
        
        var actualBooking = JsonConvert.DeserializeObject<BookingResponse>(actualBookingResponse.Content);

        actualBooking.BookingId.Should().BeOfType(typeof(int));
        actualBooking.BookingId.Should().NotBe(0);
        actualBooking.BookingId.Should().NotBe(null);
        actualBooking.Booking.Should().BeEquivalentTo(expectedBooking);
    }
    
    public void ValidateGetSingleBooking()
    {
        var bookingRequest = scenarioContext.GetRestResponsesList().First();
        var expectedBooking = JsonConvert.DeserializeObject<BookingResponse>(bookingRequest.Content);

        var actualRestResponse = scenarioContext.GetRestResponse();
        var actualBooking = JsonConvert.DeserializeObject<Booking>(actualRestResponse.Content);
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
    
    public void ValidateIfBookingHasBeenDeleted()
    {
        var expectedBookingId = scenarioContext.GetBookingId();
        GetSingleBooking(expectedBookingId);
        
        var actualRestResponse = scenarioContext.GetRestResponse();
        actualRestResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        actualRestResponse.Content.Should().NotBeNullOrEmpty();
        actualRestResponse.Content.Should().Be(ErrorMessages.NotFoundMessage);
    }
}