using System.Net;
using RestSharp;

namespace RestfulBookerTestFramework.Tests.Commons.Drivers.Validation;

public interface IValidationDriver
{
    public Task ValidateStatusCode(HttpStatusCode expectedStatusCode);

    public void ValidateCreatedBooking();

    public void ValidateUpdatedBooking(Method restRequestMethod);
    
    public void ValidatePutUpdatedBooking();

    public void ValidatePatchUpdatedBooking();
}