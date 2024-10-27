using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Models.Invalid;

public class InvalidBookingDatesWithoutCheckIn
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckOut)]
    public DateOnly CheckOut { get; set; }
}