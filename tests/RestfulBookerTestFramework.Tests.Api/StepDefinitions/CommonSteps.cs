using RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public class CommonSteps(IDeleteBookingDriver deleteBookingDriver, IGetBookingDriver getBookingDriver, IUpdateBookingDriver updateBookingDriver)
{
    [StepDefinition("trying to send '(.*)' method for not existing booking")]
    public async Task WhenTryingToUpdateBooking(Method requestMethod)
    {
        switch (requestMethod)
        {
            case Method.Delete:
                await deleteBookingDriver.TryToDeleteNotExistingBookingAsync();
                break;
            case Method.Get:
                await getBookingDriver.TryToGetNotExistingBookingAsync();
                break;
            case Method.Put:
                await updateBookingDriver.TryToPutUpdateNotExistingBookingAsync();
                break;
            default:
                throw new ArgumentOutOfRangeException(requestMethod.ToString(), $"Invalid update method {requestMethod}.");
        }
    }
}