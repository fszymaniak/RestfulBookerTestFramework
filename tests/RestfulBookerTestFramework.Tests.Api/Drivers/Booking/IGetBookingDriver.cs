namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public interface IGetBookingDriver
{
    public void GetSingleBooking(int? bookingId = null);
    
    public void ValidateGetSingleBooking();
}