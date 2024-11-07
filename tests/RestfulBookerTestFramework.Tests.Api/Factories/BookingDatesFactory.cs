using RestfulBookerTestFramework.Tests.Api.DTOs.Models;

namespace RestfulBookerTestFramework.Tests.Api.Factories;

public static class BookingDatesFactory
{
    public static BookingDates CreateBookingDates()
    {
        Faker<BookingDates> bookingDatesFaker = new Faker<BookingDates>()
            .RuleFor(b => b.CheckIn, f => f.Date.FutureDateOnly(0))
            .RuleFor(b => b.CheckOut, (f, b) => f.Date.BetweenDateOnly(b.CheckIn, b.CheckIn.AddDays(14)));

        BookingDates bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }
}