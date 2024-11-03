namespace RestfulBookerTestFramework.Tests.Api.Drivers.Booking;

public interface IGetBookingsIdsDriver
{
    public void GetMultipleBookingsIds();

    public void GetMultipleBookingsIdsWithDateFilter();

    public void GetSingleBookingIdWithNameFilter();
    
    public void ValidateMultipleBookingsIds();

    public void ValidateMultipleBookingsIdsFilteredByDate();

    public void ValidateSingleBookingIdFilteredByName();
}