using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.SingleProperty;

public class PartialBookingWithOnlyTotalPrice
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.TotalPrice)]
    public int TotalPrice { get; set; }
}