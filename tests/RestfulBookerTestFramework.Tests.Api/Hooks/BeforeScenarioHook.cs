using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Hooks;

[Binding]
public class BeforeScenarioHook(BookingHelper bookingHelper, AuthTokenRequestHelper authTokenRequestHelper)
{
    [BeforeScenario("SetupOneBooking")]
    public void BeforeScenarioSetUpOneBookings()
    {
        bookingHelper.CreateBookings(NumberOfBookings.SingleBooking);
    }
    
    [BeforeScenario("SetupMultipleBookings")]
    public void BeforeScenarioSetUpMultipleBookings()
    {
        bookingHelper.CreateBookings(NumberOfBookings.MultipleBookings);
    }
    
    [BeforeScenario("AuthorizeRequest")]
    public void BeforeScenarioAuthorizeRequest()
    {
        authTokenRequestHelper.AuthorizeRequest();
    }
}