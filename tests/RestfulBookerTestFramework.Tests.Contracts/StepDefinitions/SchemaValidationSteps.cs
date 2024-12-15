using RestfulBookerTestFramework.Tests.Contracts.Drivers;

namespace RestfulBookerTestFramework.Tests.Contracts.StepDefinitions
{
    [Binding]
    public sealed class SchemaValidationSteps(ISchemaValidationDriver schemaValidationDriver)
    {
        [Then("'(.*)' response schema is valid")]
        public void ValidateResponseSchema(string schemaSource)
        {
            schemaValidationDriver.ValidateResponseSchema(schemaSource);
        }
    }
}
