using RestfulBookerTestFramework.Tests.Api.Drivers;

namespace RestfulBookerTestFramework.Tests.Api.StepDefinitions;

[Binding]
public sealed class GetBookingSteps(IBookingDriver bookingDriver)
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
    
    [When("trying to get multiple bookings Ids with checkIn and checkOut filter")]
    public void WhenTheGetMultipleBookingsIdsWithDateFilterRequestIsSend()
    {
        bookingDriver.GetMultipleBookingsIdsWithDateFilter();
    }
    
    [When("trying to get single booking Id with first name and last name filter")]
    public void WhenTheGetSingleBookingIdWithNameFilterRequestIsSend()
    {
        bookingDriver.GetSingleBookingIdWithNameFilter();
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
    
    [Then("the multiple bookings ids filtered by dates should be exist")]
    public void ThenTheMultipleBookingsIdsFilteredByDatesShouldExist()
    {
        bookingDriver.ValidateMultipleBookingsIdsFilteredByDate();
    }
    
    [Then("the single booking id filtered by name should be exist")]
    public void ThenTheSingleBookingIdFilteredByNameShouldExist()
    {
        bookingDriver.ValidateSingleBookingIdFilteredByName();
    }
}