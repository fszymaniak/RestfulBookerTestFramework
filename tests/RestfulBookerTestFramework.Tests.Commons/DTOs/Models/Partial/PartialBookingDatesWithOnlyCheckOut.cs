using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.DTOs.Models.Partial;

public class PartialBookingDatesWithOnlyCheckOut
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckOut)]
    public string CheckOut { get; set; }
}