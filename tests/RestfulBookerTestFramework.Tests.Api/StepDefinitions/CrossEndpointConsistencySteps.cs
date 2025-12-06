using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class CrossEndpointConsistencySteps(
    ICreateBookingDriver createBookingDriver,
    IGetBookingsIdsDriver getBookingsIdsDriver,
    IUpdateBookingDriver updateBookingDriver,
    IDeleteBookingDriver deleteBookingDriver)
{
    [Then("the newly created booking should appear in GetBookingIds list")]
    public async Task ThenBookingShouldAppearInList()
    {
        var createdBookingId = createBookingDriver.GetCreatedBookingId();
        await getBookingsIdsDriver.GetAllBookingIds();

        var bookingIds = getBookingsIdsDriver.GetBookingIdsFromResponse();

        if (!bookingIds.Contains(createdBookingId))
        {
            throw new Exception($"Booking ID {createdBookingId} not found in GetBookingIds list");
        }
    }

    [Given("the booking firstname is updated to '(.*)'")]
    public void GivenBookingFirstnameIsUpdated(string newFirstname)
    {
        updateBookingDriver.GenerateUpdateRequestWithFirstname(newFirstname);
    }

    [Then("the booking should be filterable by firstname '(.*)'")]
    public async Task ThenBookingShouldBeFilterableByFirstname(string firstname)
    {
        var bookingId = updateBookingDriver.GetUpdatedBookingId();
        await getBookingsIdsDriver.GetBookingIdsByFirstname(firstname);

        var bookingIds = getBookingsIdsDriver.GetBookingIdsFromResponse();

        if (!bookingIds.Contains(bookingId))
        {
            throw new Exception($"Booking ID {bookingId} not found when filtering by firstname '{firstname}'");
        }
    }

    [Given("the existing booking has firstname '(.*)' and lastname '(.*)'")]
    public void GivenBookingHasNames(string firstname, string lastname)
    {
        updateBookingDriver.GenerateUpdateRequestWithNames(firstname, lastname);
    }

    [When("the booking is deleted")]
    public async Task WhenBookingIsDeleted()
    {
        await deleteBookingDriver.DeleteBooking();
    }

    [Then("the booking should not appear in firstname filter '(.*)'")]
    public async Task ThenBookingShouldNotAppearInFirstnameFilter(string firstname)
    {
        var deletedBookingId = deleteBookingDriver.GetDeletedBookingId();
        await getBookingsIdsDriver.GetBookingIdsByFirstname(firstname);

        var bookingIds = getBookingsIdsDriver.GetBookingIdsFromResponse();

        if (bookingIds.Contains(deletedBookingId))
        {
            throw new Exception($"Deleted booking ID {deletedBookingId} still found in firstname filter");
        }
    }

    [Then("the booking should not appear in lastname filter '(.*)'")]
    public async Task ThenBookingShouldNotAppearInLastnameFilter(string lastname)
    {
        var deletedBookingId = deleteBookingDriver.GetDeletedBookingId();
        await getBookingsIdsDriver.GetBookingIdsByLastname(lastname);

        var bookingIds = getBookingsIdsDriver.GetBookingIdsFromResponse();

        if (bookingIds.Contains(deletedBookingId))
        {
            throw new Exception($"Deleted booking ID {deletedBookingId} still found in lastname filter");
        }
    }
}
