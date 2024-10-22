using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Responses;

public class BookingResponse
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.BookingId)]
    public int BookingId { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.Booking)]
    public Booking Booking { get; set; }
}