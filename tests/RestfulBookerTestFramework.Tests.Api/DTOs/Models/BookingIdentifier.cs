using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.DTOs.Models;

public class BookingIdentifier
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.BookingId)]
    public int BookingId { get; set; }
}