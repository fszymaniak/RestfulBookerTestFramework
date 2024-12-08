namespace RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

public interface IGetBookingDriver
{
    public Task GetSingleBooking(int? bookingId = null);
    
    public void ValidateGetSingleBooking();

    public Task TryToGetNotExistingBookingAsync(int invalidBookingId = 0);
}