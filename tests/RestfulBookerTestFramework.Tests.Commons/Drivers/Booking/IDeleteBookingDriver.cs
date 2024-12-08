namespace RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

public interface IDeleteBookingDriver
{
    public Task DeleteBookingAsync();
    
    public Task TryToDeleteNotExistingBookingAsync(int invalidBookingId = 0);
    
    public Task ValidateIfBookingHasBeenDeleted();
}