using NBomber.Contracts.Stats;

namespace RestfulBookerTestFramework.Tests.Performance.Helpers;

public interface IPerformanceAssertions
{
    void ValidatePerformanceMetrics(NodeStats stats, string scenarioName);
}
