using RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Contracts.StepDefinitions;

[Binding]
public class GetBookingsIdsSteps(IGetBookingsIdsDriver getBookingsIdsDriver)
{
    [When("trying to get multiple bookings Ids")]
    public async Task WhenTheGetMultipleBookingsIdsRequestIsSend()
    {
        await getBookingsIdsDriver.GetMultipleBookingsIds();
    }
    
    [When("trying to get multiple bookings Ids with checkIn and checkOut filter")]
    public async Task WhenTheGetMultipleBookingsIdsWithDateFilterRequestIsSend()
    {
        await getBookingsIdsDriver.GetMultipleBookingsIdsWithDateFilter();
    }
    
    [When("trying to get single booking Id with first name and last name filter")]
    public async Task WhenTheGetSingleBookingIdWithNameFilterRequestIsSend()
    {
        await getBookingsIdsDriver.GetSingleBookingIdWithNameFilter();
    }
}
