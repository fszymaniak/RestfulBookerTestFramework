using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Models.Partial;

public class PartialBookingDatesWithoutCheckOut
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckIn)]
    public DateOnly CheckIn { get; set; }
}