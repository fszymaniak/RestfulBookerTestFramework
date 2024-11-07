using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models.Partial;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.SingleProperty;

namespace RestfulBookerTestFramework.Tests.Api.Factories;

public static class PartiallyBookingSinglePropertyFactory
{
    public static object GeneratePartialBookingWithMultipleProperties(string partialBookingRequest)
    {
        return partialBookingRequest switch
        {
            nameof(PartialBookingWithOnlyFirstName) => GeneratePartialBookingWithOnlyFirstName(),
            nameof(PartialBookingWithOnlyLastName) => GeneratePartialBookingWithOnlyLastName(),
            nameof(PartialBookingWithOnlyTotalPrice) => GeneratePartialBookingWithOnlyTotalPrice(),
            nameof(PartialBookingWithOnlyDepositPaid) => GeneratePartialBookingWithOnlyDepositPaid(),
            nameof(PartialBookingDatesWithoutCheckOut) => PartialBookingDatesFactory.CreateBookingDatesWithoutCheckOut(),
            nameof(PartialBookingDatesWithoutCheckIn) => PartialBookingDatesFactory.CreateBookingDatesWithoutCheckIn(),
            nameof(PartialBookingWithOnlyAdditionalNeeds) => GeneratePartialBookingWithOnlyAdditionalNeeds(),
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

    private static PartialBookingWithOnlyTotalPrice GeneratePartialBookingWithOnlyTotalPrice()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyTotalPrice> bookingFaker = new Faker<PartialBookingWithOnlyTotalPrice>()
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300));

        PartialBookingWithOnlyTotalPrice booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithOnlyDepositPaid GeneratePartialBookingWithOnlyDepositPaid()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyDepositPaid> bookingFaker = new Faker<PartialBookingWithOnlyDepositPaid>()
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool());

        PartialBookingWithOnlyDepositPaid booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithOnlyAdditionalNeeds GeneratePartialBookingWithOnlyAdditionalNeeds()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyAdditionalNeeds> bookingFaker = new Faker<PartialBookingWithOnlyAdditionalNeeds>()
                .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        PartialBookingWithOnlyAdditionalNeeds booking = bookingFaker.Generate();
        return booking;
    }
}