using System.Text.RegularExpressions;

namespace RestfulBookerTestFramework.Tests.Commons.Regex;

public partial class ResponseUriRegex
{
    [GeneratedRegex(@"\d+", RegexOptions.IgnoreCase)]
    internal static partial System.Text.RegularExpressions.Regex GetResponseUriRegex();
}