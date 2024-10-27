using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models.Invalid;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Invalid;

namespace RestfulBookerTestFramework.Tests.Api.Factories;

public static class InvalidBookingFactory
{
    public static object GenerateInvalidBooking(string invalidBookingRequest)
    {
        return invalidBookingRequest switch
        {
            nameof(InvalidBookingWithoutFirstName) => GenerateInvalidBookingWithoutFirstName(),
            nameof(InvalidBookingWithoutLastName) => GenerateInvalidBookingWithoutLastName(),
            nameof(InvalidBookingWithoutTotalPrice) => GenerateInvalidBookingWithoutTotalPrice(),
            nameof(InvalidBookingWithoutDepositPaid) => GenerateInvalidBookingWithoutDepositPaid(),
            nameof(InvalidBookingWithoutBookingDatesCheckIn) => GenerateInvalidBookingWithoutBookingDatesCheckIn(),
            nameof(InvalidBookingWithoutBookingDatesCheckOut) => GenerateInvalidBookingWithoutBookingDatesCheckOut(),
            nameof(InvalidBookingWithoutAdditionalNeeds) => GenerateInvalidBookingWithoutAdditionalNeeds(),
            _ => throw new ArgumentOutOfRangeException(nameof(invalidBookingRequest),
                $"Not expected invalid booking request value: {invalidBookingRequest}")
        };
    }

    private static InvalidBookingWithoutFirstName GenerateInvalidBookingWithoutFirstName()
    {
        BookingDates bookingDates = CreateBookingDates();

        Faker<InvalidBookingWithoutFirstName> bookingFaker = new Faker<InvalidBookingWithoutFirstName>()
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        InvalidBookingWithoutFirstName booking = bookingFaker.Generate();
        return booking;
    }

    private static InvalidBookingWithoutLastName GenerateInvalidBookingWithoutLastName()
    {
        BookingDates bookingDates = CreateBookingDates();

        Faker<InvalidBookingWithoutLastName> bookingFaker = new Faker<InvalidBookingWithoutLastName>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        InvalidBookingWithoutLastName booking = bookingFaker.Generate();
        return booking;
    }

    private static InvalidBookingWithoutTotalPrice GenerateInvalidBookingWithoutTotalPrice()
    {
        BookingDates bookingDates = CreateBookingDates();

        Faker<InvalidBookingWithoutTotalPrice> bookingFaker = new Faker<InvalidBookingWithoutTotalPrice>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        InvalidBookingWithoutTotalPrice booking = bookingFaker.Generate();
        return booking;
    }

    private static InvalidBookingWithoutDepositPaid GenerateInvalidBookingWithoutDepositPaid()
    {
        BookingDates bookingDates = CreateBookingDates();

        Faker<InvalidBookingWithoutDepositPaid> bookingFaker = new Faker<InvalidBookingWithoutDepositPaid>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        InvalidBookingWithoutDepositPaid booking = bookingFaker.Generate();
        return booking;
    }

    private static InvalidBookingWithoutBookingDatesCheckIn GenerateInvalidBookingWithoutBookingDatesCheckIn()
    {
        InvalidBookingDatesWithoutCheckIn bookingDates = CreateBookingDatesWithoutCheckIn();

        Faker<InvalidBookingWithoutBookingDatesCheckIn> bookingFaker =
            new Faker<InvalidBookingWithoutBookingDatesCheckIn>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
                .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
                .RuleFor(u => u.BookingDates, f => bookingDates)
                .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        InvalidBookingWithoutBookingDatesCheckIn booking = bookingFaker.Generate();
        return booking;
    }

    private static InvalidBookingWithoutBookingDatesCheckOut GenerateInvalidBookingWithoutBookingDatesCheckOut()
    {
        InvalidBookingDatesWithoutCheckOut bookingDates = CreateBookingDatesWithoutCheckOut();

        Faker<InvalidBookingWithoutBookingDatesCheckOut> bookingFaker =
            new Faker<InvalidBookingWithoutBookingDatesCheckOut>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
                .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
                .RuleFor(u => u.BookingDates, f => bookingDates)
                .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        InvalidBookingWithoutBookingDatesCheckOut booking = bookingFaker.Generate();
        return booking;
    }

    private static InvalidBookingWithoutAdditionalNeeds GenerateInvalidBookingWithoutAdditionalNeeds()
    {
        BookingDates bookingDates = CreateBookingDates();

        Faker<InvalidBookingWithoutAdditionalNeeds> bookingFaker = new Faker<InvalidBookingWithoutAdditionalNeeds>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates);

        InvalidBookingWithoutAdditionalNeeds booking = bookingFaker.Generate();
        return booking;
    }

    private static BookingDates CreateBookingDates()
    {
        Faker<BookingDates> bookingDatesFaker = new Faker<BookingDates>()
            .RuleFor(b => b.CheckIn, f => f.Date.FutureDateOnly(0))
            .RuleFor(b => b.CheckOut, (f, b) => f.Date.BetweenDateOnly(b.CheckIn, b.CheckIn.AddDays(14)));

        BookingDates bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }

    private static InvalidBookingDatesWithoutCheckIn CreateBookingDatesWithoutCheckIn()
    {
        Faker<InvalidBookingDatesWithoutCheckIn> bookingDatesFaker = new Faker<InvalidBookingDatesWithoutCheckIn>()
            .RuleFor(b => b.CheckOut, (f, b) => f.Date.BetweenDateOnly(b.CheckOut, b.CheckOut.AddDays(14)));

        InvalidBookingDatesWithoutCheckIn bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }

    private static InvalidBookingDatesWithoutCheckOut CreateBookingDatesWithoutCheckOut()
    {
        Faker<InvalidBookingDatesWithoutCheckOut> bookingDatesFaker =
            new Faker<InvalidBookingDatesWithoutCheckOut>()
                .RuleFor(b => b.CheckIn, f => f.Date.FutureDateOnly(0));

        InvalidBookingDatesWithoutCheckOut bookingDates = bookingDatesFaker.Generate();
        return bookingDates;
    }
}