﻿namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common;

public interface IValidationDriver
{
    public Task ValidateStatusCode(HttpStatusCode expectedStatusCode);

    public void ValidateCreatedBooking();
    
    public void ValidatePutUpdatedBooking();

    public void ValidatePatchUpdatedBooking();
}