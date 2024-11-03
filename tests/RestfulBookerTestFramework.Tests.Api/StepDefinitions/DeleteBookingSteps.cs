using RestfulBookerTestFramework.Tests.Api.Drivers;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public class DeleteBookingSteps(IBookingDriver bookingDriver)
{
    [When("trying to delete booking")]
    public void WhenTheDeleteBookingRequestIsSend()
    {
        bookingDriver.DeleteBooking();
    }
    
    [Then("the booking should be deleted and not found")]
    public void ThenTheBookingShouldBeDeletedAndNotFound()
    {
        bookingDriver.ValidateIfBookingHasBeenDeleted();
    }
}