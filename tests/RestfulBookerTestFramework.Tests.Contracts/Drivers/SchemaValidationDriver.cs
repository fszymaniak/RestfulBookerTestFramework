using RestfulBookerTestFramework.Tests.Commons.Helpers.SchemaHelpers;
using RestfulBookerTestFramework.Tests.Contracts.Constants;
using RestfulBookerTestFramework.Tests.Contracts.Resolver;

namespace RestfulBookerTestFramework.Tests.Contracts.Drivers;

public class SchemaValidationDriver(ScenarioContext scenarioContext) : ISchemaValidationDriver
{
    public async Task ValidateResponseSchema(string schemaSource)
    {
        switch (schemaSource)
        {
            case "Authentication":
                await ValidateSchemaSchema(FilePathResolver.GetSchemaFilePath(SchemaFileNames.AuthenticationSchemaFileName));
                break;
            case "CreatedBooking":
                await ValidateSchemaSchema(FilePathResolver.GetSchemaFilePath(SchemaFileNames.CreateBookingSchemaFileName));
                break;
            case "BookingsIds":
                await ValidateArraySchemaSchema(FilePathResolver.GetSchemaFilePath(SchemaFileNames.BookingsIdsSchemaFileName));
                break;
            case "Booking":
                await ValidateSchemaSchema(FilePathResolver.GetSchemaFilePath(SchemaFileNames.SingleBookingSchemaFileName));
                break;
            default:
                throw new ArgumentOutOfRangeException(schemaSource.ToString(), $"Invalid schema source {schemaSource}.");
        }
    }

    private Task ValidateSchemaSchema(string pathToSchemaFile)
    {
        var model = ObjectSchemaHelper.GetObjectSchemaModel(scenarioContext);
        var jsonSchema = JsonSchemaHelper.GetJsonSchema(pathToSchemaFile);

        ObjectSchemaHelper.ValidateObjectSchemaModel(model, jsonSchema);
        
        return Task.CompletedTask;
    }
    
    private Task ValidateArraySchemaSchema(string pathToSchemaFile)
    {
        var model = ArraySchemaHelper.GetArraySchemaModel(scenarioContext);
        var jsonSchema = JsonSchemaHelper.GetJsonSchema(pathToSchemaFile);

        ArraySchemaHelper.ValidateArraySchemaModel(model, jsonSchema);
        
        return Task.CompletedTask;
    }
}
