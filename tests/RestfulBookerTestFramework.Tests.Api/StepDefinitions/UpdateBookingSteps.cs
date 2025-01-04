using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public class UpdateBookingSteps(IUpdateBookingDriver updateBookingDriver)
{
    [StepDefinition("trying to '(.*)' update booking")]
    public async Task WhenTryingToUpdateBooking(Method requestMethod)
    {
        await updateBookingDriver.UpdateBookingAsync(requestMethod);
    }
}