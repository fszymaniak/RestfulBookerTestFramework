using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;

namespace RestfulBookerTestFramework.Tests.Api.Factories;

public static class BookingFactory
{
    public static Booking GenerateBooking()
    {
        var bookingDates = CreateBookingDates();
        
        var bookingFaker = new Faker<Booking>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());
        
        var booking = bookingFaker.Generate();
        return booking;
    }

    private static BookingDates CreateBookingDates()
    {
        var bookingDatesFaker = new Faker<BookingDates>()
            .RuleFor(b => b.CheckIn, f => f.Date.FutureDateOnly(0))
            .RuleFor(b => b.CheckOut, (f, b) => f.Date.BetweenDateOnly(b.CheckIn, b.CheckIn.AddDays(14)));

        var bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }
}