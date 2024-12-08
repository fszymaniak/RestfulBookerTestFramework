using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public class DeleteBookingSteps(IDeleteBookingDriver deleteBookingDriver)
{
    [When("trying to delete booking")]
    public async Task WhenTheDeleteBookingRequestIsSend()
    {
        await deleteBookingDriver.DeleteBookingAsync();
    }
    
    [Then("the booking should be deleted and not found")]
    public async Task ThenTheBookingShouldBeDeletedAndNotFound()
    {
        await deleteBookingDriver.ValidateIfBookingHasBeenDeleted();
    }
}
