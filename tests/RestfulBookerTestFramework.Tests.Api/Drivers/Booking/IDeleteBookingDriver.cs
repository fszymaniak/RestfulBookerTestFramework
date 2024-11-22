namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public interface IDeleteBookingDriver
{
    public Task DeleteBookingAsync();
    
    public Task TryToDeleteNotExistingBookingAsync(int invalidBookingId = 0);
    
    public Task ValidateIfBookingHasBeenDeleted();
}