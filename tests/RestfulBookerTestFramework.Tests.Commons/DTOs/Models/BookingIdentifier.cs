using System.Text.Json.Serialization;
using RestfulBookerTestFramework.Tests.Commons.Constants;

namespace RestfulBookerTestFramework.Tests.Commons.DTOs.Models;

public class BookingIdentifier
{
    [JsonPropertyName(JsonPropertyNames.BookingProperties.BookingId)]
    public int BookingId { get; set; }
}