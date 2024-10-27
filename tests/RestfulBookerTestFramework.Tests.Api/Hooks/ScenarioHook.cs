namespace RestfulBookerTestFramework.Tests.Api.Hooks;

[Binding]
public class ScenarioHook
{
    [BeforeScenario]
    public static void BeforeScenario(ScenarioContext featureContext)
    {
        Console.WriteLine("Starting " + featureContext.ScenarioInfo.Title);
    }

    [AfterScenario]
    public static void AfterScenario(ScenarioContext featureContext)
    {
        Console.WriteLine("Finished " + featureContext.ScenarioInfo.Title);
    }
}