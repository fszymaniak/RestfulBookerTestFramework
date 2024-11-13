using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common;

public class ValidationDriver(ScenarioContext scenarioContext) : IValidationDriver
{
    public Task ValidateStatusCode(HttpStatusCode expectedStatusCode)
    {
        var actualStatusCode = scenarioContext.GetRestResponse().StatusCode;
        actualStatusCode.Should().Be(expectedStatusCode);
        
        return Task.CompletedTask;
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
    
    public void ValidatePutUpdatedBooking()
    {
        var expectedBooking = scenarioContext.GetBookingRequest();
        
        var actualBookingResponse = scenarioContext.GetRestResponse();

        var actualBooking = actualBookingResponse.Deserialize<DTOs.Models.Booking>();
        
        actualBooking.Should().BeEquivalentTo(expectedBooking);
    }
    
    public void ValidatePatchUpdatedBooking()
    {
        var expectedPatchBookingRequest = scenarioContext.GetBookingRequest();
        var expectedBookingRequest = scenarioContext.GetRestResponsesList().First();
        var expectedBooking = expectedBookingRequest.Deserialize<BookingResponse>().Booking.UpdateBookingWithAnonymousObject(expectedPatchBookingRequest);
        
        var actualBookingResponse = scenarioContext.GetRestResponse();

        var actualBooking = actualBookingResponse.Deserialize<DTOs.Models.Booking>();
        
        actualBooking.Should().BeEquivalentTo(expectedBooking);
    }
}