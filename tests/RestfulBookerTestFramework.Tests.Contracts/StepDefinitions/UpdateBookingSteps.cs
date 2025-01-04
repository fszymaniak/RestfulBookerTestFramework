using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;
using RestSharp;

namespace RestfulBookerTestFramework.Tests.Contracts.StepDefinitions;

[Binding]
public class UpdateBookingSteps(IUpdateBookingDriver updateBookingDriver)
{
    [StepDefinition("trying to '(.*)' update booking")]
    public async Task WhenTryingToUpdateBooking(Method requestMethod)
    {
        await updateBookingDriver.UpdateBookingAsync(requestMethod);
    }
}