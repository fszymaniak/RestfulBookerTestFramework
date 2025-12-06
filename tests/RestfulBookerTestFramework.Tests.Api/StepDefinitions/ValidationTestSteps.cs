using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;
using RestfulBookerTestFramework.Tests.Commons.Drivers.Validation;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class ValidationTestSteps(
    ICreateBookingDriver createBookingDriver,
    IUpdateBookingDriver updateBookingDriver,
    IValidationDriver validationDriver)
{
    [When("trying to create a new booking without Content-Type header")]
    public async Task WhenTryingToCreateBookingWithoutContentType()
    {
        await createBookingDriver.CreateBookingWithoutContentType();
    }

    [When("trying to '(.*)' update booking without Content-Type header")]
    public async Task WhenTryingToUpdateBookingWithoutContentType(Method method)
    {
        if (method == Method.Put)
        {
            await updateBookingDriver.PutUpdateBookingWithoutContentType();
        }
        else if (method == Method.Patch)
        {
            await updateBookingDriver.PatchUpdateBookingWithoutContentType();
        }
    }

    [Given("a booking request with same day checkin '(.*)' and checkout '(.*)' is created")]
    public void GivenSameDayBookingRequest(string checkin, string checkout)
    {
        createBookingDriver.GenerateBookingWithDates(checkin, checkout);
    }

    [Given("a booking update request with valid firstname and invalid totalprice is created")]
    public void GivenMixedValidInvalidFieldsRequest()
    {
        createBookingDriver.GenerateBookingWithMixedValidInvalidFields();
    }

    [Given("a partial bookingdates update request with only checkin '(.*)' is created")]
    public void GivenPartialBookingdatesRequest(string checkin)
    {
        createBookingDriver.GeneratePartialBookingdatesRequest(checkin);
    }

    [Given("a booking request with null byte in firstname is created")]
    public void GivenBookingRequestWithNullByte()
    {
        createBookingDriver.GenerateBookingWithNullByteInFirstname();
    }

    [Then("status code should be '(.*)' or '(.*)'")]
    public void ThenStatusCodeShouldBeOneOf(string statusCode1, string statusCode2)
    {
        var actualStatusCode = validationDriver.GetResponseStatusCode();
        var isValid = actualStatusCode == statusCode1 || actualStatusCode == statusCode2;

        if (!isValid)
        {
            throw new Exception($"Expected status code to be {statusCode1} or {statusCode2}, but got {actualStatusCode}");
        }
    }

    [Then("the checkin date should be updated to '(.*)'")]
    public void ThenCheckinDateShouldBe(string expectedCheckin)
    {
        var booking = validationDriver.GetBookingFromResponse();
        if (booking.BookingDates.CheckIn != expectedCheckin)
        {
            throw new Exception($"Expected checkin to be {expectedCheckin}, but got {booking.BookingDates.CheckIn}");
        }
    }

    [Then("other booking fields should remain unchanged")]
    public void ThenOtherFieldsUnchanged()
    {
        validationDriver.VerifyUnchangedFieldsAfterPatch();
    }

    [Then("if booking is created then firstname should not contain null byte")]
    public void ThenFirstnameShouldNotContainNullByte()
    {
        var statusCode = validationDriver.GetResponseStatusCode();
        if (statusCode == "200")
        {
            var booking = validationDriver.GetBookingFromResponse();
            if (booking.FirstName.Contains("\0"))
            {
                throw new Exception("Firstname contains null byte character");
            }
        }
    }
}
