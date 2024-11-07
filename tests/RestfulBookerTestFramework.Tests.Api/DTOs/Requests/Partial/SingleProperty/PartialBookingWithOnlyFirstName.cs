using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.SingleProperty;

public class PartialBookingWithOnlyFirstName
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.FirstName)]
    public string FirstName { get; set; }
}