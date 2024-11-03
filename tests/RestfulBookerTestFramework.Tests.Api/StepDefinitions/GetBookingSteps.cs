using RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class GetBookingSteps(IGetBookingDriver getBookingDriver)
{
    [When("trying to get single booking")]
    public void WhenTheGetSingleBookingRequestIsSend()
    {
        getBookingDriver.GetSingleBooking();
    }
    
    [Then("the single get booking should be valid")]
    public void ThenTheGetSingleBookingShouldBeValid()
    {
        getBookingDriver.ValidateGetSingleBooking();
    }
}
