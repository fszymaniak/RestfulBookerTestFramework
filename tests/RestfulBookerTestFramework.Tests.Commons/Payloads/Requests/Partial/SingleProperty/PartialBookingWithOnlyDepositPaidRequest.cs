using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Requests.Partial.SingleProperty;

public class PartialBookingWithOnlyDepositPaidRequest
{   
    [JsonPropertyName(JsonPropertyNames.BookingProperties.DepositPaid)]
    public bool DepositPaid { get; set; }
}