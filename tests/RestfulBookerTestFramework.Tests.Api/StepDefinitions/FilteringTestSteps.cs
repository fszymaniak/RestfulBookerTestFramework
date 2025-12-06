using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class FilteringTestSteps(
    ICreateBookingDriver createBookingDriver,
    IGetBookingsIdsDriver getBookingsIdsDriver)
{
    [Given("a booking with checkin date '(.*)' and checkout date '(.*)' exists")]
    public async Task GivenBookingWithDatesExists(string checkin, string checkout)
    {
        createBookingDriver.GenerateBookingWithDates(checkin, checkout);
        await createBookingDriver.CreateBooking();
    }

    [When("requesting booking IDs with checkin filter '(.*)' and checkout filter '(.*)'")]
    public async Task WhenRequestingWithDateRangeFilter(string checkin, string checkout)
    {
        await getBookingsIdsDriver.GetBookingIdsWithDateRange(checkin, checkout);
    }

    [Then("the response should contain the booking in date range")]
    public void ThenResponseShouldContainBookingInRange()
    {
        var bookingIds = getBookingsIdsDriver.GetBookingIdsFromResponse();
        var createdBookingId = createBookingDriver.GetCreatedBookingId();

        if (!bookingIds.Contains(createdBookingId))
        {
            throw new Exception($"Expected booking ID {createdBookingId} to be in filtered results");
        }
    }
}
