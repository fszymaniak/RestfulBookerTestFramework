using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Contracts.StepDefinitions;

[Binding]
public sealed class GetBookingSteps(IGetBookingDriver getBookingDriver)
{
    [When("trying to get single booking")]
    public async Task WhenTheGetSingleBookingRequestIsSend()
    {
        await getBookingDriver.GetSingleBooking();
    }
}
