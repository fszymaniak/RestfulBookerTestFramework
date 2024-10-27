using RestfulBookerTestFramework.Tests.Api.Drivers;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class CreateBookingSteps(IBookingDriver bookingDriver)
{
    [Given("a new valid booking request is created")]
    public void GivenANewValidBookingRequestIsGenerated()
    {
        bookingDriver.GenerateBookingRequest();
    }

    [Given("the '(.*)' booking request is created")]
    public void GivenTheInvalidBookingRequestIsCreated(string invalidBookingRequest)
    {
        bookingDriver.GenerateInvalidBookingRequest(invalidBookingRequest);
    }

    [When("trying to create a new booking")]
    public void WhenTheBookingRequestIsCreated()
    {
        bookingDriver.CreateBooking();
    }
    
    [Then("the booking should be valid")]
    public void ThenTheBookingShouldBeValid()
    {
        bookingDriver.ValidateBooking();
    }
} 