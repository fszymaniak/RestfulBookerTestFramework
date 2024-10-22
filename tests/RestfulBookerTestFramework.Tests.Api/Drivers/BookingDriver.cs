using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Factories;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers;

public class BookingDriver(IRequestDriver requestDriver, ScenarioContext scenarioContext, EndpointsHelper endpointsHelper) : IBookingDriver
{
    public void GenerateBookingRequest()
    {
        var requestBookingBody = BookingFactory.GenerateBooking();

        scenarioContext.SetBookingRequest(requestBookingBody);
    }

    public void CreateBooking()
    {
        string bookingEndpoint = endpointsHelper.GetBookingEndpoint();

        var bookingRequestBody = scenarioContext.GetBookingRequest();

        var response = requestDriver.SendPostRequest(bookingEndpoint, bookingRequestBody);

        scenarioContext.SetRestResponse(response);
    }

    public void ValidateBooking()
    {
        var expectedBooking = scenarioContext.GetBookingRequest();
        
        var actualBookingResponse = scenarioContext.GetRestResponse();
        
        var actualBooking = JsonConvert.DeserializeObject<BookingResponse>(actualBookingResponse.Content);

        actualBooking.BookingId.Should().BeOfType(typeof(int));
        actualBooking.BookingId.Should().NotBe(0);
        actualBooking.BookingId.Should().NotBe(null);
        actualBooking.Booking.Should().BeEquivalentTo(expectedBooking);
    }
}