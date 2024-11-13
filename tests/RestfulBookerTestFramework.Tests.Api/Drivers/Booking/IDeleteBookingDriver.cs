namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public interface IDeleteBookingDriver
{
    public Task DeleteBookingAsync();
    
    public Task ValidateIfBookingHasBeenDeleted();
}