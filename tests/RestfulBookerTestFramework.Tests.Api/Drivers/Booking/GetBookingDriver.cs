using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public sealed class GetBookingDriver(IRequestDriver requestDriver, ScenarioContext scenarioContext, EndpointsHelper endpointsHelper, BookingHelper bookingHelper) : IGetBookingDriver
{
    public void GetSingleBooking(int? bookingId = null)
    {
        bookingId ??= bookingHelper.GetBookingId();
        string bookingEndpoint = endpointsHelper.GetSingleBookingEndpoint(bookingId);
        
        var response = requestDriver.SendGetRequest(bookingEndpoint);

        scenarioContext.SetRestResponse(response);
    }
    
    public void ValidateGetSingleBooking()
    {
        var bookingRequest = scenarioContext.GetRestResponsesList().First();
        var expectedBooking = JsonConvert.DeserializeObject<BookingResponse>(bookingRequest.Content);

        var actualRestResponse = scenarioContext.GetRestResponse();
        var actualBooking = JsonConvert.DeserializeObject<DTOs.Requests.Booking>(actualRestResponse.Content);
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
}
