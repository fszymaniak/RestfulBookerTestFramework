using System.Threading.Tasks;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Commons.Helpers;

namespace RestfulBookerTestFramework.Tests.Performance.Hooks;

[Binding]
public class AfterScenarioHook(BookingHelper bookingHelper, ScenarioContext scenarioContext)
{
    [AfterScenario("CleanUpPerformanceBookings")]
    public async Task AfterScenarioCleanUpBooking()
    {
        var bookingIds = scenarioContext.GetBookingIdsList();

        if (bookingIds.Count != 0)
        {
            foreach (var id in bookingIds)
            {
                await bookingHelper.CleanUpBookingAsync(id);
            }
        }
    }
    
    [AfterScenario("SetupMultipleBookings")]
    public async Task AfterScenarioCleanUpAllBookings()
    {
        var bookingsIds = bookingHelper.GetBookingsIds();

        foreach (var id in bookingsIds)
        {
            await bookingHelper.CleanUpBookingAsync(id);
        }
    }
}