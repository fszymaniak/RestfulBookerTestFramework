namespace RestfulBookerTestFramework.Tests.Performance.Configuration;

public class PerformanceThresholds
{
    public int MaxLatencyP50Ms { get; set; }

    public int MaxLatencyP75Ms { get; set; }

    public int MaxLatencyP95Ms { get; set; }

    public int MaxLatencyP99Ms { get; set; }

    public double MaxFailureRatePercent { get; set; }

    public int MinRequestsPerSecond { get; set; }
}
