using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Models.Partial;

public class PartialBookingDatesWithOnlyCheckOut
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckOut)]
    public string CheckOut { get; set; }
}