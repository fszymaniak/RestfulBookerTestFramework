namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public interface IUpdateBookingDriver
{
    public Task PutUpdateBookingAsync();
    
    public void PatchUpdateBooking();
}