using FluentAssertions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Reqnroll;
using RestfulBookerTestFramework.Tests.Commons.Extensions;

namespace RestfulBookerTestFramework.Tests.Commons.Helpers.SchemaHelpers;

public static class ObjectSchemaHelper
{
    public static JObject GetObjectSchemaModel(ScenarioContext scenarioContext)
    {
        var response = scenarioContext.GetRestResponse().Content;
        var modelObject = JObject.Parse(response);

        return modelObject;
    }

    public static void ValidateObjectSchemaModel(JObject modelObject, JSchema jsonSchema)
    {
        bool valid = modelObject.IsValid(jsonSchema);

        valid.Should().BeTrue();
    }
}
