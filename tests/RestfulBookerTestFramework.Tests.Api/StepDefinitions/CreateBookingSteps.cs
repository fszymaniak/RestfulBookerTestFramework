using RestfulBookerTestFramework.Tests.Api.Drivers.Booking;
using RestfulBookerTestFramework.Tests.Commons.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class CreateBookingSteps(ICreateBookingDriver createBookingDriver)
{
    [Given("a new valid booking request is created")]
    public void GivenANewValidBookingRequestIsGenerated()
    {
        createBookingDriver.GenerateBookingRequest();
    }
    
    [StepDefinition("the '(.*)' booking with single property for invalid request is created")]
    [StepDefinition("the '(.*)' booking with single property request is created")]
    public void GivenThePartialBookingWithSinglePropertyRequestIsCreated(string partialBookingWithSinglePropertyRequest)
    {
        createBookingDriver.GeneratePartiallyBookingWithSinglePropertyRequest(partialBookingWithSinglePropertyRequest.AddRequestPostFix());
    }

    [StepDefinition("the '(.*)' booking property for invalid request is created")]
    [StepDefinition("the '(.*)' booking request is created")]
    public void GivenThePartialBookingWithMultiplePropertiesRequestIsCreated(string partialBookingRequest)
    {
        createBookingDriver.GeneratePartiallyBookingWithMultiplePropertiesRequest(partialBookingRequest.AddRequestPostFix());
    }

    [When("trying to create a new booking")]
    public async Task WhenTheBookingRequestIsCreated()
    {
        await createBookingDriver.CreateBooking();
    }
    
   
}
