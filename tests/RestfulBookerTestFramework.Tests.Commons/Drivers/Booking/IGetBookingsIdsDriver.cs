namespace RestfulBookerTestFramework.Tests.Commons.Drivers.Booking;

public interface IGetBookingsIdsDriver
{
    public Task GetMultipleBookingsIds();

    public Task GetMultipleBookingsIdsWithDateFilter();

    public Task GetSingleBookingIdWithNameFilter();
    
    public void ValidateMultipleBookingsIds();

    public void ValidateMultipleBookingsIdsFilteredByDate();

    public void ValidateSingleBookingIdFilteredByName();
}