using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Requests.Partial.SingleProperty;

public class PartialBookingWithOnlyTotalPriceRequest
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.TotalPrice)]
    public int TotalPrice { get; set; }
}