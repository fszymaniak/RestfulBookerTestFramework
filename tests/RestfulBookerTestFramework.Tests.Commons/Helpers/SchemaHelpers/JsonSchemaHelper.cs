using Newtonsoft.Json.Schema;

namespace RestfulBookerTestFramework.Tests.Commons.Helpers.SchemaHelpers;

public static class JsonSchemaHelper
{
    public static JSchema GetJsonSchema(string pathToSchemaFile)
    {
        string schema = File.ReadAllText(pathToSchemaFile);
        var jsonSchema = JSchema.Parse(schema);
        
        return jsonSchema;
    }
}
