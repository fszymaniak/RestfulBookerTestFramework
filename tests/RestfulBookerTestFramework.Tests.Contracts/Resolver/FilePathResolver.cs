using RestfulBookerTestFramework.Tests.Contracts.Constants;

namespace RestfulBookerTestFramework.Tests.Contracts.Resolver;

public static class FilePathResolver
{
    public static string GetSchemaFilePath(string schemaFileName) => Path.Combine(SchemaFolderNames.SchemaFolderName, $"{schemaFileName}.json");
}
