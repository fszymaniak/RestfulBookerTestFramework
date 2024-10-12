namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common;

public interface IValidationDriver
{
    public void ValidateStatusCode(HttpStatusCode expectedStatusCode);

    public void ValidateCreatedBooking();
    
    public void ValidatePutUpdatedBooking();

    public void ValidatePatchUpdatedBooking();
}