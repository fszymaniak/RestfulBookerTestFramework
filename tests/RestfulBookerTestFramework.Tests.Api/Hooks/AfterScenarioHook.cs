using RestfulBookerTestFramework.Tests.Api.DTOs.Models;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Hooks;

[Binding]
public class AfterScenarioHook(BookingHelper bookingHelper, ScenarioContext scenarioContext)
{
    [AfterScenario("CleanUpBooking")]
    public void AfterScenarioCleanUpBooking()
    {
        RestResponse restResponse = null;
        try
        {
            restResponse = scenarioContext.GetRestResponse();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        int bookingId = restResponse.Deserialize<BookingIdentifier>().BookingId;

        if (bookingId != 0)
        {
            bookingHelper.CleanUpBooking(bookingId);
        }
    }
    
    [AfterScenario("SetupMultipleBookings")]
    public void AfterScenarioCleanUpAllBookings(ScenarioContext scenarioContext)
    {
        var bookingsIds = bookingHelper.GetBookingsIds();

        foreach (var id in bookingsIds)
        {
            bookingHelper.CleanUpBooking(id);
        }
    }
}