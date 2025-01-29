using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Requests;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Responses;
using RestSharp;

namespace RestfulBookerTestFramework.Tests.Commons.Extensions;

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
    
    public static void SetBookingIdsList(this ScenarioContext context, List<int> bookingIdList) =>
        context[Context.BookingIdsList] = bookingIdList;
    
    public static void SetRestResponsesList(this ScenarioContext context, List<RestResponse> response) =>
        context[Context.ResponseList] = response;
    
    public static void SetAuthTokenResponse(this ScenarioContext context, AuthTokenResponse response) =>
        context[Context.AuthTokenResponse] = response;
}