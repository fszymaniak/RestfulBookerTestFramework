using RestfulBookerTestFramework.Tests.Api.Drivers;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class GetBookingSteps(IBookingDriver bookingDriver, BookingHelper bookingHelper)
{
    [When("trying to get single booking")]
    public void WhenTheGetSingleBookingRequestIsSend()
    {
        bookingDriver.GetSingleBooking();
    }
    
    [When("trying to get multiple bookings Ids")]
    public void WhenTheGetMultipleBookingsIdsRequestIsSend()
    {
        bookingDriver.GetMultipleBookingsIds();
    }
    
    [Then("the single get booking should be valid")]
    public void ThenTheGetSingleBookingShouldBeValid()
    {
        bookingDriver.ValidateGetSingleBooking();
    }
    
    [Then("the multiple bookings ids should be exist")]
    public void ThenTheMultipleBookingsIdsShouldExist()
    {
        bookingDriver.ValidateMultipleBookingsIds();
    }
}