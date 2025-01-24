using System.IO;
using Autofac;
using Microsoft.Extensions.Configuration;
using Reqnroll.Autofac;
using Reqnroll.Autofac.ReqnrollPlugin;
using RestfulBookerTestFramework.Tests.Commons.Configuration;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Performance.Configuration;
using RestfulBookerTestFramework.Tests.Performance.Helpers;
using RestfulBookerTestFramework.Tests.Performance.StepDefinitions;
using ContainerBuilder = Autofac.ContainerBuilder;

namespace RestfulBookerTestFramework.Tests.Performance.Support;

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
        
        // Helpers
        containerBuilder
            .RegisterType<IPerformanceHelper>()
            .As<PerformanceHelper>()
            .SingleInstance();
        
        // register binding classes
        containerBuilder.AddReqnrollBindings<PerformanceSteps>();
        containerBuilder.AddReqnrollBindings<HealthCheckSteps>();
    }
}