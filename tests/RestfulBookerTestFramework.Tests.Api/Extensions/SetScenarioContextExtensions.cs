using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;

namespace RestfulBookerTestFramework.Tests.Api.Extensions;

public static class SetScenarioContextExtensions
{
    public static void SetAuthTokenRequest(this ScenarioContext context, AuthTokenRequest authTokenRequest) =>
        context[Context.AuthTokenRequest] = authTokenRequest;

    public static void SetRestResponse(this ScenarioContext context, RestResponse response) =>
        context[Context.Response] = response;
    
    public static void SetBookingRequest(this ScenarioContext context, object bookingRequest) =>
        context[Context.BookingRequest] = bookingRequest;
    
    public static void SetBookingId(this ScenarioContext context, int bookingId) =>
        context[Context.BookingId] = bookingId;
    
    public static void SetRestResponsesList(this ScenarioContext context, List<RestResponse> response) =>
        context[Context.ResponseList] = response;
    
    public static void SetAuthTokenResponse(this ScenarioContext context, AuthTokenResponse response) =>
        context[Context.AuthTokenResponse] = response;
}