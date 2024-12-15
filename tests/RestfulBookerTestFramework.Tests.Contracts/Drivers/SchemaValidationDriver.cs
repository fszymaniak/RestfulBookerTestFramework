using System;
using System.IO;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Reqnroll;
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
            default:
                throw new ArgumentOutOfRangeException(schemaSource.ToString(), $"Invalid schema source {schemaSource}.");
        }
    }

    private void ValidateSchemaSchema(string pathToSchemaFile)
    {
        var response = scenarioContext.GetRestResponse().Content;
        
        string schema = File.ReadAllText(pathToSchemaFile);

        var model = JObject.Parse(response);
        var jsonSchema = JSchema.Parse(schema);

        bool valid = model.IsValid(jsonSchema);

        valid.Should().BeTrue();
    }
}