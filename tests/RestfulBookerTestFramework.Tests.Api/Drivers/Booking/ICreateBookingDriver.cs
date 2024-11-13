namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public interface ICreateBookingDriver
{
    public void GenerateBookingRequest();

    public void GeneratePartiallyBookingWithSinglePropertyRequest(string partialBookingRequest);
    
    public void GeneratePartiallyBookingWithMultiplePropertiesRequest(string partialBookingRequest);

    public Task CreateBooking();
}
