using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models.Partial;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.MultipleProperties;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.SingleProperty;

namespace RestfulBookerTestFramework.Tests.Api.Factories;

public static class PartiallyBookingSinglePropertyFactory
{
    public static object GeneratePartialBookingWithMultipleProperties(string partialBookingRequest)
    {
        return partialBookingRequest switch
        {
            nameof(PartialBookingWithOnlyFirstName) => GeneratePartialBookingWithOnlyFirstName(),
            nameof(PartialBookingWithoutLastName) => GeneratePartialBookingWithOnlyLastName(),
            nameof(PartialBookingWithoutTotalPrice) => GeneratePartialBookingWithoutTotalPrice(),
            nameof(InvalidBookingWithoutDepositPaid) => GeneratePartialBookingWithoutDepositPaid(),
            nameof(PartialBookingWithoutBookingDatesCheckIn) => GeneratePartialBookingWithoutBookingDatesCheckIn(),
            nameof(PartialBookingWithoutBookingDatesCheckOut) => GeneratePartialBookingWithoutBookingDatesCheckOut(),
            nameof(PartialBookingWithoutAdditionalNeeds) => GeneratePartialBookingWithoutAdditionalNeeds(),
            _ => throw new ArgumentOutOfRangeException(nameof(partialBookingRequest),
                $"Not expected invalid booking request value: {partialBookingRequest}")
        };
    }

    private static PartialBookingWithOnlyFirstName GeneratePartialBookingWithOnlyFirstName()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyFirstName> bookingFaker = new Faker<PartialBookingWithOnlyFirstName>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName());

        PartialBookingWithOnlyFirstName booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithOnlyLastName GeneratePartialBookingWithOnlyLastName()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyLastName> bookingFaker = new Faker<PartialBookingWithOnlyLastName>()
            .RuleFor(u => u.LastName, f => f.Name.LastName());

        PartialBookingWithOnlyLastName booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithOnlyTotalPrice GeneratePartialBookingWithoutTotalPrice()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyTotalPrice> bookingFaker = new Faker<PartialBookingWithOnlyTotalPrice>()
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300));

        PartialBookingWithOnlyTotalPrice booking = bookingFaker.Generate();
        return booking;
    }

    private static InvalidBookingWithoutDepositPaid GeneratePartialBookingWithoutDepositPaid()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<InvalidBookingWithoutDepositPaid> bookingFaker = new Faker<InvalidBookingWithoutDepositPaid>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        InvalidBookingWithoutDepositPaid booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithoutBookingDatesCheckIn GeneratePartialBookingWithoutBookingDatesCheckIn()
    {
        PartialBookingDatesWithoutCheckIn bookingDates = PartialBookingDatesFactory.CreateBookingDatesWithoutCheckIn();

        Faker<PartialBookingWithoutBookingDatesCheckIn> bookingFaker =
            new Faker<PartialBookingWithoutBookingDatesCheckIn>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
                .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
                .RuleFor(u => u.BookingDates, f => bookingDates)
                .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        PartialBookingWithoutBookingDatesCheckIn booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithoutBookingDatesCheckOut GeneratePartialBookingWithoutBookingDatesCheckOut()
    {
        PartialBookingDatesWithoutCheckOut
            bookingDates = PartialBookingDatesFactory.CreateBookingDatesWithoutCheckOut();

        Faker<PartialBookingWithoutBookingDatesCheckOut> bookingFaker =
            new Faker<PartialBookingWithoutBookingDatesCheckOut>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
                .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
                .RuleFor(u => u.BookingDates, f => bookingDates)
                .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        PartialBookingWithoutBookingDatesCheckOut booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithoutAdditionalNeeds GeneratePartialBookingWithoutAdditionalNeeds()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithoutAdditionalNeeds> bookingFaker = new Faker<PartialBookingWithoutAdditionalNeeds>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates);

        PartialBookingWithoutAdditionalNeeds booking = bookingFaker.Generate();
        return booking;
    }
}