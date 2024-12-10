namespace RestfulBookerTestFramework.Tests.Contracts.Drivers;

public interface ISchemaValidationDriver
{
    public void ValidateResponseSchema(string schemaSource);

}