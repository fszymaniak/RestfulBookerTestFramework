using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Performance.StepDefinitions;

[Binding]
public sealed class CreateBookingSteps(ICreateBookingDriver createBookingDriver)
{
    [Given("a new valid booking request is created")]
    public void GivenANewValidBookingRequestIsGenerated()
    {
        createBookingDriver.GenerateBookingRequest();
    }
}
