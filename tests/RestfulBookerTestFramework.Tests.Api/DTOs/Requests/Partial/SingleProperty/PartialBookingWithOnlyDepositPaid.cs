using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.SingleProperty;

public class PartialBookingWithOnlyDepositPaid
{   
    [JsonPropertyName(JsonPropertyNames.BookingProperties.DepositPaid)]
    public bool DepositPaid { get; set; }
}