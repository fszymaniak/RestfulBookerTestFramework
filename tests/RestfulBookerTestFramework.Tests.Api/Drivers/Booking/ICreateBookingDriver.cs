namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public interface ICreateBookingDriver
{
    public void GenerateBookingRequest();
    
    public void GenerateInvalidBookingRequest(string invalidBookingRequest);

    public void CreateBooking();

    public void ValidateCreatedBooking();
}
