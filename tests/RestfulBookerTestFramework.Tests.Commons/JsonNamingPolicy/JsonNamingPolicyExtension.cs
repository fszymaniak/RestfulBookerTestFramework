namespace RestfulBookerTestFramework.Tests.Commons.JsonNamingPolicy;

public abstract class JsonNamingPolicyExtension
{
    public static System.Text.Json.JsonNamingPolicy LowerCase { get; } = new LowerCaseNamingPolicy();
}
