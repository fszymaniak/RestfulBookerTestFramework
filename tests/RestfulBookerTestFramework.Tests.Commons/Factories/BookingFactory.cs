using Bogus;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.DTOs.Models;

namespace RestfulBookerTestFramework.Tests.Commons.Factories;

public static class BookingFactory
{
    public static List<Booking> GenerateBookings(int bookingNumber = 1)
    {
        var bookingDates = BookingDatesFactory.CreateBookingDates();
        
        var bookingFaker = new Faker<Booking>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());
        
        var booking = bookingFaker.Generate(bookingNumber);
        return booking;
    }
}