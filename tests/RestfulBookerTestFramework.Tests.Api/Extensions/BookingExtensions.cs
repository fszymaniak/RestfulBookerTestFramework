using RestfulBookerTestFramework.Tests.Api.DTOs.Models;

namespace RestfulBookerTestFramework.Tests.Api.Extensions;

public static class BookingExtensions
{
    public static Booking UpdateBookingWithAnonymousObject(this Booking booking, object anonymousObject)
    {
        var firstNameProperty = anonymousObject.GetType().GetProperty(nameof(Booking.FirstName));
        var lastNameProperty = anonymousObject.GetType().GetProperty(nameof(Booking.LastName));
        var totalPriceProperty = anonymousObject.GetType().GetProperty(nameof(Booking.TotalPrice));
        var depositPaidProperty = anonymousObject.GetType().GetProperty(nameof(Booking.DepositPaid));
        var bookingDatesProperty = anonymousObject.GetType().GetProperty(nameof(Booking.BookingDates));
        var additionalNeedsProperty = anonymousObject.GetType().GetProperty(nameof(Booking.AdditionalNeeds));
            
        if (firstNameProperty != null)
        {
            booking.FirstName = (string)firstNameProperty.GetValue(anonymousObject);
        }

        if (lastNameProperty != null)
        {
            booking.LastName = (string)lastNameProperty.GetValue(anonymousObject);
        }
        
        if (totalPriceProperty != null)
        {
            booking.TotalPrice = (int?)totalPriceProperty.GetValue(anonymousObject);
        }
        
        if (depositPaidProperty != null)
        {
            booking.DepositPaid = (bool?)depositPaidProperty.GetValue(anonymousObject);
        }
        
        if (bookingDatesProperty != null)
        {
            booking.UpdateBookingDatesWithAnonymousObject(anonymousObject, bookingDatesProperty);
        }
        
        if (additionalNeedsProperty != null)
        {
            booking.AdditionalNeeds = (string)additionalNeedsProperty.GetValue(anonymousObject);
        }

        return booking;
    }

    public static void UpdateBookingDatesWithAnonymousObject(this Booking booking, object anonymousObject, PropertyInfo bookingDatesProperty)
    {
        var bookingDatesValue = bookingDatesProperty.GetValue(anonymousObject);
                        
        var checkInProperty = bookingDatesValue.GetType().GetProperty(nameof(Booking.BookingDates.CheckIn));
        var checkOutProperty = bookingDatesValue.GetType().GetProperty(nameof(Booking.BookingDates.CheckOut));
            
        if (checkInProperty != null)
        {
            booking.BookingDates.CheckIn = (string)checkInProperty.GetValue(bookingDatesValue);
        }
            
        if (checkOutProperty != null)
        {
            booking.BookingDates.CheckOut = (string)checkOutProperty.GetValue(bookingDatesValue);
        }
    }
}