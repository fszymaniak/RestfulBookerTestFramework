using RestfulBookerTestFramework.Tests.Api.Drivers;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class GetBookingSteps(IBookingDriver bookingDriver, BookingHelper bookingHelper)
{
    [When("trying to get single booking")]
    public void WhenTheBookingRequestIsCreated()
    {
        bookingDriver.GetSingleBooking();
    }
    
    [Then("the single get booking should be valid")]
    public void ThenTheGetSingleBookingShouldBeValid()
    {
        bookingDriver.ValidateGetSingleBooking();
    }
}