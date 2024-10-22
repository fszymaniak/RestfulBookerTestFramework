using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Models;

public class BookingDates
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckIn)]
    public DateOnly CheckIn { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckOut)]
    public DateOnly CheckOut { get; set; }
}