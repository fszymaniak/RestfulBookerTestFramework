using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common;

public class ValidationDriver(ScenarioContext scenarioContext) : IValidationDriver
{
    public void ValidateStatusCode(HttpStatusCode expectedStatusCode)
    {
        var actualStatusCode = scenarioContext.GetRestResponse().StatusCode;
        actualStatusCode.Should().Be(expectedStatusCode);
    }
    
    public void ValidateCreatedBooking()
    {
        var expectedBooking = scenarioContext.GetBookingRequest();
        
        var actualBookingResponse = scenarioContext.GetRestResponse();

        var actualBooking = actualBookingResponse.Deserialize<BookingResponse>();

        actualBooking.BookingId.Should().BeOfType(typeof(int));
        actualBooking.BookingId.Should().NotBe(0);
        actualBooking.BookingId.Should().NotBe(null);
        actualBooking.Booking.Should().BeEquivalentTo(expectedBooking);
    }
    
    public void ValidateUpdatedBooking()
    {
        var expectedBooking = scenarioContext.GetBookingRequest();
        
        var actualBookingResponse = scenarioContext.GetRestResponse();

        var actualBooking = actualBookingResponse.Deserialize<DTOs.Models.Booking>();

        actualBooking.Should().BeEquivalentTo(expectedBooking);
    }
}