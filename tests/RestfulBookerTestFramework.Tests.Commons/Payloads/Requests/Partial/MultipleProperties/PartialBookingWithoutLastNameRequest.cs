using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.DTOs.Models;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Requests.Partial.MultipleProperties;

public class PartialBookingWithoutLastNameRequest
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.FirstName)]
    public string FirstName { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.TotalPrice)]
    public int TotalPrice { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.DepositPaid)]
    public bool DepositPaid { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.BookingDates)]
    public BookingDates BookingDates { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.AdditionalNeeds)]
    public string AdditionalNeeds { get; set; }
}