using RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class CreateBookingSteps(ICreateBookingDriver createBookingDriver)
{
    [Given("a new valid booking request is created")]
    public void GivenANewValidBookingRequestIsGenerated()
    {
        createBookingDriver.GenerateBookingRequest();
    }

    [Given("the '(.*)' booking request is created")]
    public void GivenTheInvalidBookingRequestIsCreated(string invalidBookingRequest)
    {
        createBookingDriver.GenerateInvalidBookingRequest(invalidBookingRequest);
    }

    [When("trying to create a new booking")]
    public void WhenTheBookingRequestIsCreated()
    {
        createBookingDriver.CreateBooking();
    }
    
   
}
