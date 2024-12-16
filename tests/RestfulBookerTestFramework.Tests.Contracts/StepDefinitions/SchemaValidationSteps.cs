using RestfulBookerTestFramework.Tests.Contracts.Drivers;

namespace RestfulBookerTestFramework.Tests.Contracts.StepDefinitions
{
    [Binding]
    public sealed class SchemaValidationSteps(ISchemaValidationDriver schemaValidationDriver)
    {
        [Then("'(.*)' response schema is valid")]
        public async Task ValidateResponseSchema(string schemaSource)
        {
            await schemaValidationDriver.ValidateResponseSchema(schemaSource);
        }
    }
}
