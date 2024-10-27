using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;
using RestfulBookerTestFramework.Tests.Api.Factories;

namespace RestfulBookerTestFramework.Tests.Api.Extensions
{
    public static class GetScenarioContextExtensions
    {
        public static AuthTokenRequest GetAuthTokenRequest(this ScenarioContext context) =>
            context.Get<AuthTokenRequest>(Context.AuthTokenRequest);

        public static RestResponse GetRestResponse(this ScenarioContext context) =>
            context.Get<RestResponse>(Context.Response);
        
        public static object GetBookingRequest(this ScenarioContext context) =>
            context.Get<object>(Context.BookingRequest);
    }
}
