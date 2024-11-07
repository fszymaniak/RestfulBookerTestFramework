using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.SingleProperty;

public class PartialBookingWithOnlyLastName
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.LastName)]
    public string LastName { get; set; }
}