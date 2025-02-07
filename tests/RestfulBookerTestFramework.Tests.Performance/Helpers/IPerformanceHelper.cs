using System.Net.Http;

namespace RestfulBookerTestFramework.Tests.Performance.Helpers;

public interface IPerformanceHelper
{
    public HttpRequestMessage CreatePerformanceRequest(string method, string endpoint, int? id = null);
}