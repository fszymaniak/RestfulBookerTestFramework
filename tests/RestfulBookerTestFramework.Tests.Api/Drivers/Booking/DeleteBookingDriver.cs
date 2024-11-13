using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.Drivers.AuthToken;
using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public sealed class DeleteBookingDriver(IRequestDriver requestDriver, ScenarioContext scenarioContext, EndpointsHelper endpointsHelper, IAuthTokenDriver authTokenDriver, AppSettings appSettings, IGetBookingDriver getBookingDriver) : IDeleteBookingDriver
{
    public void DeleteBooking()
    {
        var expectedBookingResponse = scenarioContext.GetRestResponsesList().FirstOrDefault();
        var bookingId = expectedBookingResponse.Deserialize<BookingIdentifier>();
        scenarioContext.SetBookingId(bookingId.BookingId);
        authTokenDriver.CreateAuthTokenRequest(appSettings.Credentials.UserName, appSettings.Credentials.Password);
        authTokenDriver.CreateAuthTokenAsync();
        
        string deleteBookingEndpoint = endpointsHelper.GetDeleteBookingEndpoint(bookingId.BookingId);
        
        var response = requestDriver.SendDeleteRequest(deleteBookingEndpoint);

        scenarioContext.SetRestResponse(response);
    }
    
    public void ValidateIfBookingHasBeenDeleted()
    {
        var expectedBookingId = scenarioContext.GetBookingId();
        getBookingDriver.GetSingleBooking(expectedBookingId);
        
        var actualRestResponse = scenarioContext.GetRestResponse();
        actualRestResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        actualRestResponse.Content.Should().NotBeNullOrEmpty();
        actualRestResponse.Content.Should().Be(ErrorMessages.NotFoundMessage);
    }
}
