using System;
using System.Linq;
using NBomber.Contracts.Stats;
using NUnit.Framework;
using RestfulBookerTestFramework.Tests.Performance.Configuration;

namespace RestfulBookerTestFramework.Tests.Performance.Helpers;

public class PerformanceAssertions(PerformanceSettings performanceSettings) : IPerformanceAssertions
{
    public void ValidatePerformanceMetrics(NodeStats stats, string scenarioName)
    {
        var thresholds = performanceSettings.Thresholds;
        var scenarioStats = stats.ScenarioStats.FirstOrDefault(s => s.ScenarioName == scenarioName);

        if (scenarioStats == null)
        {
            Assert.Fail($"No statistics found for scenario: {scenarioName}");
            return;
        }

        Console.WriteLine($"\n========== Performance Results for '{scenarioName}' ==========");
        Console.WriteLine($"Total Requests: {scenarioStats.Ok.Request.Count + scenarioStats.Fail.Request.Count}");
        Console.WriteLine($"Successful Requests: {scenarioStats.Ok.Request.Count}");
        Console.WriteLine($"Failed Requests: {scenarioStats.Fail.Request.Count}");
        Console.WriteLine($"Requests Per Second (RPS): {scenarioStats.Ok.Request.RPS}");
        Console.WriteLine($"\nLatency Percentiles:");
        Console.WriteLine($"  P50: {scenarioStats.Ok.Latency.Percent50} ms");
        Console.WriteLine($"  P75: {scenarioStats.Ok.Latency.Percent75} ms");
        Console.WriteLine($"  P95: {scenarioStats.Ok.Latency.Percent95} ms");
        Console.WriteLine($"  P99: {scenarioStats.Ok.Latency.Percent99} ms");
        Console.WriteLine($"  Min: {scenarioStats.Ok.Latency.MinMs} ms");
        Console.WriteLine($"  Max: {scenarioStats.Ok.Latency.MaxMs} ms");
        Console.WriteLine($"  Mean: {scenarioStats.Ok.Latency.MeanMs} ms");

        var totalRequests = scenarioStats.Ok.Request.Count + scenarioStats.Fail.Request.Count;
        var failureRate = totalRequests > 0
            ? (double)scenarioStats.Fail.Request.Count / totalRequests * 100
            : 0;

        Console.WriteLine($"\nFailure Rate: {failureRate:F2}%");
        Console.WriteLine("==========================================================\n");

        // Assert on latency thresholds
        Assert.That(scenarioStats.Ok.Latency.Percent50, Is.LessThanOrEqualTo(thresholds.MaxLatencyP50Ms),
            $"P50 latency ({scenarioStats.Ok.Latency.Percent50}ms) exceeded threshold ({thresholds.MaxLatencyP50Ms}ms)");

        Assert.That(scenarioStats.Ok.Latency.Percent75, Is.LessThanOrEqualTo(thresholds.MaxLatencyP75Ms),
            $"P75 latency ({scenarioStats.Ok.Latency.Percent75}ms) exceeded threshold ({thresholds.MaxLatencyP75Ms}ms)");

        Assert.That(scenarioStats.Ok.Latency.Percent95, Is.LessThanOrEqualTo(thresholds.MaxLatencyP95Ms),
            $"P95 latency ({scenarioStats.Ok.Latency.Percent95}ms) exceeded threshold ({thresholds.MaxLatencyP95Ms}ms)");

        Assert.That(scenarioStats.Ok.Latency.Percent99, Is.LessThanOrEqualTo(thresholds.MaxLatencyP99Ms),
            $"P99 latency ({scenarioStats.Ok.Latency.Percent99}ms) exceeded threshold ({thresholds.MaxLatencyP99Ms}ms)");

        // Assert on failure rate
        Assert.That(failureRate, Is.LessThanOrEqualTo(thresholds.MaxFailureRatePercent),
            $"Failure rate ({failureRate:F2}%) exceeded threshold ({thresholds.MaxFailureRatePercent}%)");

        // Assert on minimum RPS
        Assert.That(scenarioStats.Ok.Request.RPS, Is.GreaterThanOrEqualTo(thresholds.MinRequestsPerSecond),
            $"RPS ({scenarioStats.Ok.Request.RPS}) is below minimum threshold ({thresholds.MinRequestsPerSecond})");

        Console.WriteLine($"✓ All performance thresholds passed for scenario '{scenarioName}'");
    }
}
