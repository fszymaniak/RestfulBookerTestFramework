using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Models.Partial;

public class PartialBookingDatesWithOnlyCheckIn
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckIn)]
    public string CheckIn { get; set; }
}