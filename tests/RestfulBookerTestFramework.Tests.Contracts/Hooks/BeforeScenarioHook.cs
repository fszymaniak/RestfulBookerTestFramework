using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Hooks;

[Binding]
public class BeforeScenarioHook(BookingHelper bookingHelper, AuthTokenRequestHelper authTokenRequestHelper)
{
    [BeforeScenario("SetupOneBooking")]
    public async Task BeforeScenarioSetUpOneBookingsAsync()
    {
        await bookingHelper.CreateBookings(NumberOfBookings.SingleBooking);
    }

    [BeforeScenario("SetupMultipleBookings")]
    public async Task BeforeScenarioSetUpMultipleBookingsAsync()
    {
        await bookingHelper.CreateBookings(NumberOfBookings.MultipleBookings);
    }

    [BeforeScenario("AuthorizeRequest")]
    public async Task BeforeScenarioAuthorizeRequest()
    {
        await authTokenRequestHelper.AuthorizeRequestAsync();
    }
}