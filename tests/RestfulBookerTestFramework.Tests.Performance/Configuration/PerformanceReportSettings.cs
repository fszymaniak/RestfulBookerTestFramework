namespace RestfulBookerTestFramework.Tests.Performance.Configuration;

public class PerformanceReportSettings
{
    public bool Enabled { get; set; }

    public string ReportFolder { get; set; } = "performance-reports";

    public string[] ReportFormats { get; set; } = { "Html", "Md" };
}
