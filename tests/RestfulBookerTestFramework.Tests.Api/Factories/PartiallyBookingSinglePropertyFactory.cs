using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.DTOs.Models.Partial;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.SingleProperty;

namespace RestfulBookerTestFramework.Tests.Api.Factories;

public static class PartiallyBookingSinglePropertyFactory
{
    public static object GeneratePartialBookingWithSingleProperties(string partialBookingRequest)
    {
        return partialBookingRequest switch
        {
            nameof(PartialBookingWithOnlyFirstNameRequest) => GeneratePartialBookingWithOnlyFirstName(),
            nameof(PartialBookingWithOnlyLastNameRequest) => GeneratePartialBookingWithOnlyLastName(),
            nameof(PartialBookingWithOnlyTotalPriceRequest) => GeneratePartialBookingWithOnlyTotalPrice(),
            nameof(PartialBookingWithOnlyDepositPaidRequest) => GeneratePartialBookingWithOnlyDepositPaid(),
            nameof(PartialBookingDatesWithOnlyCheckInRequest) => PartialBookingDatesFactory.CreateBookingDatesRequestWithOnlyCheckIn(),
            nameof(PartialBookingDatesWithOnlyCheckOutRequest) => PartialBookingDatesFactory.CreateBookingDatesRequestWithOnlyCheckOut(),
            nameof(PartialBookingWithOnlyAdditionalNeedsRequest) => GeneratePartialBookingWithOnlyAdditionalNeeds(),
            _ => throw new ArgumentOutOfRangeException(nameof(partialBookingRequest),
                $"Not expected invalid booking request value: {partialBookingRequest}")
        };
    }

    private static PartialBookingWithOnlyFirstNameRequest GeneratePartialBookingWithOnlyFirstName()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyFirstNameRequest> bookingFaker = new Faker<PartialBookingWithOnlyFirstNameRequest>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName());

        PartialBookingWithOnlyFirstNameRequest booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithOnlyLastNameRequest GeneratePartialBookingWithOnlyLastName()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyLastNameRequest> bookingFaker = new Faker<PartialBookingWithOnlyLastNameRequest>()
            .RuleFor(u => u.LastName, f => f.Name.LastName());

        PartialBookingWithOnlyLastNameRequest booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithOnlyTotalPriceRequest GeneratePartialBookingWithOnlyTotalPrice()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyTotalPriceRequest> bookingFaker = new Faker<PartialBookingWithOnlyTotalPriceRequest>()
            .RuleFor(u => u.TotalPrice, f => f.Random.Int(50, 300));

        PartialBookingWithOnlyTotalPriceRequest booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithOnlyDepositPaidRequest GeneratePartialBookingWithOnlyDepositPaid()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyDepositPaidRequest> bookingFaker = new Faker<PartialBookingWithOnlyDepositPaidRequest>()
            .RuleFor(u => u.DepositPaid, f => f.Random.Bool());

        PartialBookingWithOnlyDepositPaidRequest booking = bookingFaker.Generate();
        return booking;
    }

    private static PartialBookingWithOnlyAdditionalNeedsRequest GeneratePartialBookingWithOnlyAdditionalNeeds()
    {
        BookingDates bookingDates = BookingDatesFactory.CreateBookingDates();

        Faker<PartialBookingWithOnlyAdditionalNeedsRequest> bookingFaker = new Faker<PartialBookingWithOnlyAdditionalNeedsRequest>()
                .RuleFor(u => u.AdditionalNeeds, f => f.Random.Enum<AdditionalNeeds>().ToString());

        PartialBookingWithOnlyAdditionalNeedsRequest booking = bookingFaker.Generate();
        return booking;
    }
}