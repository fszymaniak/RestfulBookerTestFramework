#nullable enable
using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.DTOs.Models;

public class Booking
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.FirstName)]
    public string? FirstName { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.LastName)]
    public string? LastName { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.TotalPrice)]
    public int? TotalPrice { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.DepositPaid)]
    public bool? DepositPaid { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.BookingDates)]
    public BookingDates? BookingDates { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.AdditionalNeeds)]
    public string? AdditionalNeeds { get; set; }
}