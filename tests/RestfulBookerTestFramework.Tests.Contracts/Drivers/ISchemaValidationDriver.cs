namespace RestfulBookerTestFramework.Tests.Contracts.Drivers;

public interface ISchemaValidationDriver
{
    public Task ValidateResponseSchema(string schemaSource);

}