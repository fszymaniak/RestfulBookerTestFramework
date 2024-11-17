using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;

namespace RestfulBookerTestFramework.Tests.Api.Extensions;

public static class RestResponseExtensions
{
    public static T Deserialize<T>(this RestResponse response)
    {
        return JsonConvert.DeserializeObject<T>(response.Content);
    }

    public static void SetBookingId(this RestResponse response, ScenarioContext scenarioContext)
    {
        var bookingResponse = response.Deserialize<BookingResponse>();
        scenarioContext.SetBookingId(bookingResponse.BookingId);
    }
}