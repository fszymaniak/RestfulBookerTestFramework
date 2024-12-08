using RestfulBookerTestFramework.Tests.Api.Configuration;
using ContainerBuilder = Autofac.ContainerBuilder;
using RestfulBookerTestFramework.Tests.Api.Hooks;
using RestfulBookerTestFramework.Tests.Api.StepDefinitions;
using RestfulBookerTestFramework.Tests.Commons.Configuration;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Support;

public static class SetupTestDependencies
{
    [GlobalDependencies]
    public static void SetupGlobalContainer(ContainerBuilder containerBuilder)
    {
        // Register globally scoped runtime dependencies
        // register RestfulBookerTestFramework.Tests.Commons configuration dependencies
        containerBuilder.AddCommonDependenciesGlobalContainer();
        
        // configuration
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(FileNames.AppSettingsJson, optional: true, reloadOnChange: true)
            .AddUserSecrets<TestBaseSetup>()
            .Build();

        var appSettingsConfig = config.GetSection(nameof(AppSettings)).Get<AppSettings>();

        containerBuilder.RegisterInstance(appSettingsConfig).AsSelf().SingleInstance();
        containerBuilder.RegisterInstance(config).As<IConfiguration>().SingleInstance();
    }

    [ScenarioDependencies]
    public static void SetupScenarioContainer(ContainerBuilder containerBuilder)
    {
        // Register scenario scoped runtime dependencies
        containerBuilder.AddCommonDependenciesScenarioContainer();
        
        // register binding classes
        containerBuilder.AddReqnrollBindings<ScenarioHook>();
        containerBuilder.AddReqnrollBindings<BeforeScenarioHook>();
        containerBuilder.AddReqnrollBindings<CreateTokenSteps>();
        containerBuilder.AddReqnrollBindings<ValidationSteps>();
        containerBuilder.AddReqnrollBindings<CreateBookingSteps>();
        containerBuilder.AddReqnrollBindings<GetBookingSteps>();
        containerBuilder.AddReqnrollBindings<GetBookingsIdsSteps>();
        containerBuilder.AddReqnrollBindings<DeleteBookingSteps>();
        containerBuilder.AddReqnrollBindings<HealthCheckSteps>();
    }
}