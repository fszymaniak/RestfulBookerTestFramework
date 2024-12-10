using RestfulBookerTestFramework.Tests.Contracts.Constants;

namespace RestfulBookerTestFramework.Tests.Contracts.Resolver;

public static class FilePathResolver
{
    public static string GetSchemaFilePath(string schemaFileName) => $@"{SchemaFolderNames.SchemaFolderName}\{schemaFileName}.json";
}
