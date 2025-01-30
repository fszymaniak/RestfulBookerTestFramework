namespace RestfulBookerTestFramework.Tests.Commons.JsonNamingPolicy;

public class LowerCaseNamingPolicy : System.Text.Json.JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name) || !char.IsUpper(name[0]))
            return name;

        return name.ToLower();
    }
}
