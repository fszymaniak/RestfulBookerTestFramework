using RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public class DeleteBookingSteps(IDeleteBookingDriver deleteBookingDriver)
{
    [When("trying to delete booking")]
    public void WhenTheDeleteBookingRequestIsSend()
    {
        deleteBookingDriver.DeleteBooking();
    }
    
    [Then("the booking should be deleted and not found")]
    public void ThenTheBookingShouldBeDeletedAndNotFound()
    {
        deleteBookingDriver.ValidateIfBookingHasBeenDeleted();
    }
}
