using FluentAssertions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Extensions;

namespace RestfulBookerTestFramework.Tests.Commons.Helpers.SchemaHelpers;

public static class ArraySchemaHelper
{
    public static JArray GetArraySchemaModel(ScenarioContext scenarioContext)
    {
        var response = scenarioContext.GetRestResponse().Content;
        var modeArray = JArray.Parse(response);

        return modeArray;
    }
    
    public static void ValidateArraySchemaModel(JArray modelObject, JSchema jsonSchema)
    {
        bool valid = modelObject.IsValid(jsonSchema);

        valid.Should().BeTrue();
    }
}
