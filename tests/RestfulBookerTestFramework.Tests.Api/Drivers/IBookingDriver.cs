namespace RestfulBookerTestFramework.Tests.Api.Drivers;

public interface IBookingDriver
{
    public void GenerateBookingRequest();
    
    public void GenerateInvalidBookingRequest(string invalidBookingRequest);

    public void CreateBooking();

    public void GetSingleBooking();
    
    public void ValidateCreatedBooking();

    public void ValidateGetSingleBooking();
}