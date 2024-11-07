using RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public class UpdateBookingSteps(IUpdateBookingDriver updateBookingDriver)
{
    [StepDefinition("trying to PUT update booking")]
    public void CreateValidAuthTokenAsync()
    {
        updateBookingDriver.PutUpdateBooking();
    }
}