using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Requests.Partial.SingleProperty;

public class PartialBookingWithOnlyLastNameRequest
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.LastName)]
    public string LastName { get; set; }
}