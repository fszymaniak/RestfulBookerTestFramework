using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.DTOs.Models.Partial;

namespace RestfulBookerTestFramework.Tests.Commons.Payloads.Requests.Partial.SingleProperty;

public class PartialBookingDatesWithOnlyCheckOutRequest
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.BookingDates)]
    public PartialBookingDatesWithOnlyCheckOut BookingDates { get; set; }
}