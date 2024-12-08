using System.Net;

namespace RestfulBookerTestFramework.Tests.Commons.Drivers;

public interface IValidationDriver
{
    public Task ValidateStatusCode(HttpStatusCode expectedStatusCode);

    public void ValidateCreatedBooking();
    
    public void ValidatePutUpdatedBooking();

    public void ValidatePatchUpdatedBooking();
}