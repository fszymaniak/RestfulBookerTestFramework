namespace RestfulBookerTestFramework.Tests.Commons.Extensions;

public static class DateOnlyExtensions
{
    public static string ConvertToValidStringTimeFormat(this DateOnly date)
    {
        return date.ToString("yyyy-MM-dd");
    }
}