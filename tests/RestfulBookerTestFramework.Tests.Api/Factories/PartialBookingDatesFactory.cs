using RestfulBookerTestFramework.Tests.Api.DTOs.Models.Partial;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.SingleProperty;
using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Factories;

public static class PartialBookingDatesFactory
{
    public static PartialBookingDatesWithOnlyCheckOutRequest CreateBookingDatesRequestWithOnlyCheckOut()
    {
        var bookingDatesWithOnlyCheckOut = CreateBookingDatesWithOnlyCheckOut();
        
        Faker<PartialBookingDatesWithOnlyCheckOutRequest> bookingDatesFaker = new Faker<PartialBookingDatesWithOnlyCheckOutRequest>()
            .RuleFor(b => b.BookingDates, bookingDatesWithOnlyCheckOut);

        PartialBookingDatesWithOnlyCheckOutRequest bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }

    public static PartialBookingDatesWithOnlyCheckInRequest CreateBookingDatesRequestWithOnlyCheckIn()
    {
        var bookingDatesWithOnlyCheckOut = CreateBookingDatesWithOnlyCheckIn();
        
        Faker<PartialBookingDatesWithOnlyCheckInRequest> bookingDatesFaker =
            new Faker<PartialBookingDatesWithOnlyCheckInRequest>()
                .RuleFor(b => b.BookingDates, bookingDatesWithOnlyCheckOut);

        PartialBookingDatesWithOnlyCheckInRequest bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }
    
    public static PartialBookingDatesWithOnlyCheckOut CreateBookingDatesWithOnlyCheckOut()
    {
        var dateTimeNow = DateTime.Now;
        var startDate = DateOnly.FromDateTime(dateTimeNow);
        
        Faker<PartialBookingDatesWithOnlyCheckOut> bookingDatesFaker = new Faker<PartialBookingDatesWithOnlyCheckOut>()
            .RuleFor(b => b.CheckOut, (f, b) => f.Date.BetweenDateOnly(startDate, startDate.AddDays(14)).ConvertToValidStringTimeFormat());

        PartialBookingDatesWithOnlyCheckOut bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }
    
    public static PartialBookingDatesWithOnlyCheckIn CreateBookingDatesWithOnlyCheckIn()
    {
        Faker<PartialBookingDatesWithOnlyCheckIn> bookingDatesFaker =
            new Faker<PartialBookingDatesWithOnlyCheckIn>()
                .RuleFor(b => b.CheckIn, f => f.Date.FutureDateOnly(0).ConvertToValidStringTimeFormat());

        PartialBookingDatesWithOnlyCheckIn bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }
}