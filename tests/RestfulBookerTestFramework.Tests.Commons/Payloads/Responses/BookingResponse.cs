using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.DTOs.Models;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Responses;

public class BookingResponse
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.BookingId)]
    public int BookingId { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.Booking)]
    public Booking Booking { get; set; }
}