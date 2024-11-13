namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public interface IDeleteBookingDriver
{
    public void DeleteBooking();
    
    public Task ValidateIfBookingHasBeenDeleted();
}