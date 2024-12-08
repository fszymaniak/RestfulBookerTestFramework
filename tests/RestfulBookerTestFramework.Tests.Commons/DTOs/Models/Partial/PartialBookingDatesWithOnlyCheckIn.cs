using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.DTOs.Models.Partial;

public class PartialBookingDatesWithOnlyCheckIn
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckIn)]
    public string CheckIn { get; set; }
}