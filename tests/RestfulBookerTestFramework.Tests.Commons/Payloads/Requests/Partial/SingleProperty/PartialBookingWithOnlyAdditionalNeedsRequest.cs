using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Requests.Partial.SingleProperty;

public class PartialBookingWithOnlyAdditionalNeedsRequest
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.AdditionalNeeds)]
    public string AdditionalNeeds { get; set; }
}