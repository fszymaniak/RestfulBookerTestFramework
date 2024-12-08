using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public class UpdateBookingSteps(IUpdateBookingDriver updateBookingDriver)
{
    [StepDefinition("trying to '(.*)' update booking")]
    public async Task WhenTryingToUpdateBooking(Method requestMethod)
    {
        switch (requestMethod)
        {
            case Method.Put:
                await updateBookingDriver.PutUpdateBookingAsync();
                break;
            case Method.Patch:
                await updateBookingDriver.PatchUpdateBooking();
                break;
            default:
                throw new ArgumentOutOfRangeException(requestMethod.ToString(), $"Invalid update method {requestMethod}. Expected Method should be PUT or PATCH.");
        }
    }
}