using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Models.Invalid;

public class InvalidBookingDatesWithoutCheckOut
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckIn)]
    public DateOnly CheckIn { get; set; }
}