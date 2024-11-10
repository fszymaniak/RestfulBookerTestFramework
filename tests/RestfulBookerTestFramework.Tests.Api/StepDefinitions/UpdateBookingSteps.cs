using RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public class UpdateBookingSteps(IUpdateBookingDriver updateBookingDriver)
{
    [StepDefinition("trying to '(.*)' update booking")]
    public void WhenTryingToUpdateBooking(Method requestMethod)
    {
        switch (requestMethod)
        {
            case Method.Put:
                updateBookingDriver.PutUpdateBooking();
                break;
            case Method.Patch:
                updateBookingDriver.PatchUpdateBooking();
                break;
            default:
                throw new ArgumentOutOfRangeException(requestMethod.ToString(), "Invalid method");
        }
    }
}