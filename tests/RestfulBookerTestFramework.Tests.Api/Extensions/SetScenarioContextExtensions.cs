using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;

namespace RestfulBookerTestFramework.Tests.Api.Extensions;

public static class SetScenarioContextExtensions
{
    public static void SetAuthTokenRequest(this ScenarioContext context, AuthTokenRequest authTokenRequest) =>
        context[Context.AuthTokenRequest] = authTokenRequest;

    public static void SetRestResponse(this ScenarioContext context, RestResponse response) =>
        context[Context.Response] = response;
    
    public static void SetBookingRequest(this ScenarioContext context, object bookingRequest) =>
        context[Context.BookingRequest] = bookingRequest;
}