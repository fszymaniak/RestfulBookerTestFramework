using RestfulBookerTestFramework.Tests.Api.Constants;

namespace RestfulBookerTestFramework.Tests.Api.Helpers;

public static class DateHelper
{
    public static string GetCheckIn() => DateTime.Today.ToString("yyyy-MM-dd");
    
    public static string GetCheckOut() => DateTime.Today.AddDays(DateConstants.MaxFutureDaysForCheckOut).ToString("yyyy-MM-dd");
}