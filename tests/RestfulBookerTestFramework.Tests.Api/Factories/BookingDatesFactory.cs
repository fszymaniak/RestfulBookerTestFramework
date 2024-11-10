using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Factories;

public static class BookingDatesFactory
{
    public static BookingDates CreateBookingDates()
    {
        Faker<BookingDates> bookingDatesFaker = new Faker<BookingDates>()
            .RuleFor(b => b.CheckIn, f => (f.Date.FutureDateOnly(0).ConvertToValidStringTimeFormat()))
            .RuleFor(b => b.CheckOut, (f, b) => (f.Date.BetweenDateOnly(b.CheckIn.ParseToValidDateOnlyFormat(), b.CheckIn.ToString().ParseToValidDateOnlyFormat().AddDays(14)).ConvertToValidStringTimeFormat()));

        BookingDates bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }
}