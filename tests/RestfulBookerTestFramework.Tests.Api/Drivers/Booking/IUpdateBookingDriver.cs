namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public interface IUpdateBookingDriver
{
    public Task PutUpdateBookingAsync();
    
    public Task PatchUpdateBooking();
    
    public Task TryToPutUpdateNotExistingBookingAsync(int invalidBookingId = 0);
}