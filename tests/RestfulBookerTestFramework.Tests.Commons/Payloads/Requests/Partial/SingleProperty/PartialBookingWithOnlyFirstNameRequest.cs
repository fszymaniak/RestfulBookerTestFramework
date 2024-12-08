using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Requests.Partial.SingleProperty;

public class PartialBookingWithOnlyFirstNameRequest
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.FirstName)]
    public string FirstName { get; set; }
}