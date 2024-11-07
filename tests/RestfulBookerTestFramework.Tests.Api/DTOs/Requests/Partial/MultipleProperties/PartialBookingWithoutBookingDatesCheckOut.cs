using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models.Partial;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.MultipleProperties;

public class PartialBookingWithoutBookingDatesCheckOut
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.FirstName)]
    public string FirstName { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.LastName)]
    public string LastName { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.TotalPrice)]
    public int TotalPrice { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.DepositPaid)]
    public bool DepositPaid { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.BookingDates)]
    public PartialBookingDatesWithoutCheckOut BookingDates { get; set; }
    
    [JsonPropertyName(JsonPropertyNames.BookingProperties.AdditionalNeeds)]
    public string AdditionalNeeds { get; set; }
}