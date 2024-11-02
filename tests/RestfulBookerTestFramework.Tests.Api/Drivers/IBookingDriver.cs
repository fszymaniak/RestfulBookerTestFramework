namespace RestfulBookerTestFramework.Tests.Api.Drivers;

public interface IBookingDriver
{
    public void GenerateBookingRequest();
    
    public void GenerateInvalidBookingRequest(string invalidBookingRequest);

    public void CreateBooking();

    public void GetSingleBooking();

    public void GetMultipleBookingsIds();

    public void GetMultipleBookingsIdsWithDateFilter();

    public void GetSingleBookingIdWithNameFilter();
    
    public void ValidateCreatedBooking();

    public void ValidateGetSingleBooking();

    public void ValidateMultipleBookingsIds();

    public void ValidateMultipleBookingsIdsFilteredByDate();

    public void ValidateSingleBookingIdFilteredByName();
}