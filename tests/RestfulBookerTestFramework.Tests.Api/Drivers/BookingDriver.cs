using System.Linq;

using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Factories;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers;

public class BookingDriver(IRequestDriver requestDriver, ScenarioContext scenarioContext, EndpointsHelper endpointsHelper, BookingHelper bookingHelper) : IBookingDriver
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

    public void GetSingleBooking()
    {
        int bookingId = bookingHelper.GetBookingId();
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
        var bookingRequest = scenarioContext.GetRestResponseList().First();
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
}