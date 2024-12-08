#nullable enable
using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.DTOs.Models;

public class BookingDates
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckIn)]
    public string? CheckIn { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.CheckOut)]
    public string? CheckOut { get; set; }
}