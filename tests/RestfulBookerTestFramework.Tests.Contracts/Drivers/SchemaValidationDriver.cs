
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Contracts.Constants;
using RestfulBookerTestFramework.Tests.Contracts.Resolver;

namespace RestfulBookerTestFramework.Tests.Contracts.Drivers;

public class SchemaValidationDriver(ScenarioContext scenarioContext) : ISchemaValidationDriver
{
    public void ValidateResponseSchema(string schemaSource)
    {
        switch (schemaSource)
        {
            case "Authentication":
                ValidateSchemaSchema(FilePathResolver.GetSchemaFilePath(SchemaFileNames.AuthenticationSchemaFileName));
                break;
            case "BookingCreation":
                ValidateSchemaSchema(FilePathResolver.GetSchemaFilePath(SchemaFileNames.CreateBookingSchemaFileName));
                break;
            case "BookingsIds":
                ValidateArraySchemaSchema(FilePathResolver.GetSchemaFilePath(SchemaFileNames.BookingsIdsSchemaFileName));
                break;
            default:
                throw new ArgumentOutOfRangeException(schemaSource.ToString(), $"Invalid schema source {schemaSource}.");
        }
    }

    private void ValidateSchemaSchema(string pathToSchemaFile)
    {
        var model = GetObjectSchemaModel();
        var jsonSchema = GetJsonSchema(pathToSchemaFile);

        bool valid = model.IsValid(jsonSchema);

        valid.Should().BeTrue();
    }
    
    private void ValidateArraySchemaSchema(string pathToSchemaFile)
    {
        var model = GetArraySchemaModel();
        var jsonSchema = GetJsonSchema(pathToSchemaFile);

        bool valid = model.IsValid(jsonSchema);

        valid.Should().BeTrue();
    }

    private JSchema GetJsonSchema(string pathToSchemaFile)
    {
        string schema = File.ReadAllText(pathToSchemaFile);
        var jsonSchema = JSchema.Parse(schema);
        
        return jsonSchema;
    }

    private JObject GetObjectSchemaModel()
    {
        var response = scenarioContext.GetRestResponse().Content;
        var modelObject = JObject.Parse(response);

        return modelObject;
    }
    
    private JArray GetArraySchemaModel()
    {
        var response = scenarioContext.GetRestResponse().Content;
        var modeArray = JArray.Parse(response);

        return modeArray;
    }
}