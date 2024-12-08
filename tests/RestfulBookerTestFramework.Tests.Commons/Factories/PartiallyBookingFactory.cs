using Bogus;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.DTOs.Models;
using RestfulBookerTestFramework.Tests.Commons.DTOs.Models.Partial;
using RestfulBookerTestFramework.Tests.Commons.Payloads.Requests.Partial.MultipleProperties;

namespace RestfulBookerTestFramework.Tests.Commons.Factories;

public static class PartiallyBookingFactory
{
    public static object GeneratePartialBookingWithMultipleProperties(string partialBookingRequest)
    {
        return partialBookingRequest switch
        {
            nameof(PartialBookingWithoutFirstNameRequest) => GeneratePartialBookingWithoutFirstName(),
            nameof(PartialBookingWithoutLastNameRequest) => GeneratePartialBookingWithoutLastName(),
            nameof(PartialBookingWithoutTotalPriceRequest) => GeneratePartialBookingWithoutTotalPrice(),
            nameof(PartialBookingWithoutDepositPaidRequest) => GeneratePartialBookingWithoutDepositPaid(),
            nameof(PartialBookingWithoutBookingDatesCheckInRequest) => GeneratePartialBookingWithoutBookingDatesCheckIn(),
            nameof(PartialBookingWithoutBookingDatesCheckOutRequest) => GeneratePartialBookingWithoutBookingDatesCheckOut(),
            nameof(PartialBookingWithoutAdditionalNeedsRequest) => GeneratePartialBookingWithoutAdditionalNeeds(),
            _ => throw new ArgumentOutOfRangeException(nameof(partialBookingRequest),
                $"Not expected invalid booking request value: {partialBookingRequest}")
        };
    }

    private static PartialBookingWithoutFirstNameRequest GeneratePartialBookingWithoutFirstName()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithoutFirstNameRequest> bookingFaker = new Faker<PartialBookingWithoutFirstNameRequest>()
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        PartialBookingWithoutFirstNameRequest booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithoutLastNameRequest GeneratePartialBookingWithoutLastName()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithoutLastNameRequest> bookingFaker = new Faker<PartialBookingWithoutLastNameRequest>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        PartialBookingWithoutLastNameRequest booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithoutTotalPriceRequest GeneratePartialBookingWithoutTotalPrice()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithoutTotalPriceRequest> bookingFaker = new Faker<PartialBookingWithoutTotalPriceRequest>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        PartialBookingWithoutTotalPriceRequest booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithoutDepositPaidRequest GeneratePartialBookingWithoutDepositPaid()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithoutDepositPaidRequest> bookingFaker = new Faker<PartialBookingWithoutDepositPaidRequest>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.BookingDates, f => bookingDates)
            .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        PartialBookingWithoutDepositPaidRequest booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithoutBookingDatesCheckInRequest GeneratePartialBookingWithoutBookingDatesCheckIn()
    {
        PartialBookingDatesWithOnlyCheckOut bookingDates = PartialBookingDatesFactory.CreateBookingDatesWithOnlyCheckOut();

        Faker<PartialBookingWithoutBookingDatesCheckInRequest> bookingFaker =
            new Faker<PartialBookingWithoutBookingDatesCheckInRequest>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
                .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
                .RuleFor(u => u.BookingDates, f => bookingDates)
                .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        PartialBookingWithoutBookingDatesCheckInRequest booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithoutBookingDatesCheckOutRequest GeneratePartialBookingWithoutBookingDatesCheckOut()
    {
        PartialBookingDatesWithOnlyCheckIn
            bookingDates = PartialBookingDatesFactory.CreateBookingDatesWithOnlyCheckIn();

        Faker<PartialBookingWithoutBookingDatesCheckOutRequest> bookingFaker =
            new Faker<PartialBookingWithoutBookingDatesCheckOutRequest>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
                .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
                .RuleFor(u => u.BookingDates, f => bookingDates)
                .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        PartialBookingWithoutBookingDatesCheckOutRequest booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithoutAdditionalNeedsRequest GeneratePartialBookingWithoutAdditionalNeeds()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithoutAdditionalNeedsRequest> bookingFaker = new Faker<PartialBookingWithoutAdditionalNeedsRequest>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300))
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool())
            .RuleFor(u => u.BookingDates, f => bookingDates);

        PartialBookingWithoutAdditionalNeedsRequest booking = bookingFaker.Generate();
        return booking;
    }
}