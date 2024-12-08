using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Requests;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Responses;
using RestSharp;

namespace RestfulBookerTestFramework.Tests.Commons.Extensions
{
    public static class GetScenarioContextExtensions
    {
        public static AuthTokenRequest GetAuthTokenRequest(this ScenarioContext context) =>
            context.Get<AuthTokenRequest>(Context.AuthTokenRequest);

        public static RestResponse GetRestResponse(this ScenarioContext context) =>
            context.Get<RestResponse>(Context.Response);
        
        public static object GetBookingRequest(this ScenarioContext context) =>
            context.Get<object>(Context.BookingRequest);
        
        public static int GetBookingId(this ScenarioContext context) =>
            context.Get<int>(Context.BookingId);
        
        public static List<RestResponse> GetRestResponsesList(this ScenarioContext context) =>
            context.Get<List<RestResponse>>(Context.ResponseList);
        
        public static AuthTokenResponse GetAuthTokenResponse(this ScenarioContext context) =>
            context.Get<AuthTokenResponse>(Context.AuthTokenResponse);
    }
}
