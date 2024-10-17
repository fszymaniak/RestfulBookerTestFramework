namespace RestfulBookerTestFramework.Tests.Api.Drivers
{
    public interface ICommonDriver
    {
        public void ValidateStatusCode(HttpStatusCode expectedStatusCode);

        public void ValidateHealthCheckBeforeScenarioRun();
    }
}
