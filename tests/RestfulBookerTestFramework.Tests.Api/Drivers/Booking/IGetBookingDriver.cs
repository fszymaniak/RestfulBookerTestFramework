namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public interface IGetBookingDriver
{
    public Task GetSingleBooking(int? bookingId = null);
    
    public void ValidateGetSingleBooking();
}