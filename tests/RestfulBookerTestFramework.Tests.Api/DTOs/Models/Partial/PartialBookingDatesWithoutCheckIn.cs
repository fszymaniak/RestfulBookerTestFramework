using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Models.Partial;

public class PartialBookingDatesWithoutCheckIn
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckOut)]
    public DateOnly CheckOut { get; set; }
}