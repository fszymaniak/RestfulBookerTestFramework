using System.Net;
using FluentAssertions;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Responses;
using RestSharp;

namespace RestfulBookerTestFramework.Tests.Commons.Drivers.Validation;

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

        var actualBooking = actualBookingResponse.Deserialize<Commons.DTOs.Models.Booking>();
        
        actualBooking.Should().BeEquivalentTo(expectedBooking);
    }
    
    public void ValidatePatchUpdatedBooking()
    {
        var expectedPatchBookingRequest = scenarioContext.GetBookingRequest();
        var expectedBookingRequest = scenarioContext.GetRestResponsesList().First();
        var expectedBooking = expectedBookingRequest.Deserialize<BookingResponse>().Booking.UpdateBookingWithAnonymousObject(expectedPatchBookingRequest);
        
        var actualBookingResponse = scenarioContext.GetRestResponse();

        var actualBooking = actualBookingResponse.Deserialize<Commons.DTOs.Models.Booking>();
        
        actualBooking.Should().BeEquivalentTo(expectedBooking);
    }

    public void ValidateUpdatedBooking(Method restRequestMethod)
    {
        switch (restRequestMethod)
        {
            case Method.Put:
                ValidatePutUpdatedBooking();
                break;
            case Method.Patch:
                ValidatePatchUpdatedBooking();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(restRequestMethod), restRequestMethod, null);
        }
    }
}