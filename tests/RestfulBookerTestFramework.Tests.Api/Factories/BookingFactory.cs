using System.Collections.Generic;

using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests;

namespace RestfulBookerTestFramework.Tests.Api.Factories;

public static class BookingFactory
{
    public static List<Booking> GenerateBookings(int bookingNumber = 1)
    {
        var bookingDates = CreateBookingDates();
        
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

    private static BookingDates CreateBookingDates()
    {
        var bookingDatesFaker = new Faker<BookingDates>()
            .RuleFor(b => b.CheckIn, f => f.Date.FutureDateOnly(DateConstants.CheckInYearsToGoForward))
            .RuleFor(b => b.CheckOut, (f, b) => f.Date.BetweenDateOnly(b.CheckIn, b.CheckIn.AddDays(DateConstants.MaxFutureDaysForCheckOut)));

        var bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }
}