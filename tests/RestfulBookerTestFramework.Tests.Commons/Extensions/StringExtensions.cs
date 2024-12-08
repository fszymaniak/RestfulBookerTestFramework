namespace RestfulBookerTestFramework.Tests.Commons.Extensions;

public static class StringExtensions
{
    public static string AddRequestPostFix(this string request)
    {
        return request + "Request";
    }
    
    public static DateOnly ParseToValidDateOnlyFormat(this string value)
    {
        return DateOnly.Parse(value);
    }
}