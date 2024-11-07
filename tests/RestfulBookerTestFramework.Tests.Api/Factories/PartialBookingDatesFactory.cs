using RestfulBookerTestFramework.Tests.Api.DTOs.Models.Partial;

namespace RestfulBookerTestFramework.Tests.Api.Factories;

public static class PartialBookingDatesFactory
{
    public static PartialBookingDatesWithoutCheckIn CreateBookingDatesWithoutCheckIn()
    {
        Faker<PartialBookingDatesWithoutCheckIn> bookingDatesFaker = new Faker<PartialBookingDatesWithoutCheckIn>()
            .RuleFor(b => b.CheckOut, (f, b) => f.Date.BetweenDateOnly(b.CheckOut, b.CheckOut.AddDays(14)));

        PartialBookingDatesWithoutCheckIn bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }

    public static PartialBookingDatesWithoutCheckOut CreateBookingDatesWithoutCheckOut()
    {
        Faker<PartialBookingDatesWithoutCheckOut> bookingDatesFaker =
            new Faker<PartialBookingDatesWithoutCheckOut>()
                .RuleFor(b => b.CheckIn, f => f.Date.FutureDateOnly(0));

        PartialBookingDatesWithoutCheckOut bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }
}