using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Models;

public class BookingDates
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckIn)]
    public string CheckIn { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckOut)]
    public string CheckOut { get; set; }
}