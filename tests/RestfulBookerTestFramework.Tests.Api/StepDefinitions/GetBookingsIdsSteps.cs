using RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

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
    
    [Then("the multiple bookings ids should be exist")]
    public void ThenTheMultipleBookingsIdsShouldExist()
    {
        getBookingsIdsDriver.ValidateMultipleBookingsIds();
    }
    
    [Then("the multiple bookings ids filtered by dates should be exist")]
    public void ThenTheMultipleBookingsIdsFilteredByDatesShouldExist()
    {
        getBookingsIdsDriver.ValidateMultipleBookingsIdsFilteredByDate();
    }
    
    [Then("the single booking id filtered by name should be exist")]
    public void ThenTheSingleBookingIdFilteredByNameShouldExist()
    {
        getBookingsIdsDriver.ValidateSingleBookingIdFilteredByName();
    }
}
