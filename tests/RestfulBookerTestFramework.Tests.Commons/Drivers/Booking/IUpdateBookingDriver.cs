using RestSharp;

namespace RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

public interface IUpdateBookingDriver
{
    public Task UpdateBookingAsync(Method requestMethod);
    
    public Task TryToPutUpdateNotExistingBookingAsync(int invalidBookingId = 0);
    
    public Task TryToPatchUpdateNotExistingBookingAsync(int invalidBookingId = 0);
}