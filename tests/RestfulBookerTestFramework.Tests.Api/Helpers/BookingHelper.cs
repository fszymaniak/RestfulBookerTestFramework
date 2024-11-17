using RestfulBookerTestFramework.Tests.Api.Drivers.Common;
using RestfulBookerTestFramework.Tests.Api.DTOs.Requests.Partial.SingleProperty;
using RestfulBookerTestFramework.Tests.Api.DTOs.Responses;
using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Factories;

namespace RestfulBookerTestFramework.Tests.Api.Helpers;

public class BookingHelper(ScenarioContext scenarioContext, EndpointsHelper endpointsHelper, IRequestDriver requestDriver)
{
    public async Task CreateBookings(int numberOfBookings)
    {
        var requestBookingBody = BookingFactory.GenerateBookings(numberOfBookings);

        string bookingEndpoint = endpointsHelper.GetBookingEndpoint();

        List<RestResponse> restResponsesList = new ();

        foreach (var bookingBody in requestBookingBody)
        {
            var response = await requestDriver.SendPostRequestAsync(bookingEndpoint, bookingBody);
            restResponsesList.Add(response);
        }
        
        scenarioContext.SetRestResponsesList(restResponsesList);
    }

    public int GetBookingId()
    {
        var bookingRequest = scenarioContext.GetRestResponsesList().First();
        var booking = JsonConvert.DeserializeObject<BookingResponse>(bookingRequest.Content);
        scenarioContext.SetBookingId(booking.BookingId);

        return booking.BookingId;
    }
    
    public List<int> GetBookingsIds()
    {
        var bookingIdentifiers = scenarioContext.GetRestResponsesList()
            .Select(r => r.Deserialize<BookingResponse>());
        var bookingIds = bookingIdentifiers.Select(i => i.BookingId).ToList();

        return bookingIds;
    }

    public async Task CleanUpBookingAsync(int bookingId)
    {
        string deleteBookingEndpoint = endpointsHelper.GetDeleteBookingEndpoint(bookingId);
        
        await requestDriver.SendDeleteRequestAsync(deleteBookingEndpoint);
    }
}