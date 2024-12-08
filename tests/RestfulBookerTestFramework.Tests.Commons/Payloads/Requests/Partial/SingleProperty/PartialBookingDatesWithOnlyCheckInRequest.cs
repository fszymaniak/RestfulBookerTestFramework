using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.DTOs.Models.Partial;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Requests.Partial.SingleProperty;

public class PartialBookingDatesWithOnlyCheckInRequest
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.BookingDates)]
    public PartialBookingDatesWithOnlyCheckIn BookingDates { get; set; }
}