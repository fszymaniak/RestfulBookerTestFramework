namespace RestfulBookerTestFramework.Tests.Api.Drivers;

public interface IBookingDriver
{
    public void GenerateBookingRequest();

    public void CreateBooking();
    
    public void ValidateBooking();
}