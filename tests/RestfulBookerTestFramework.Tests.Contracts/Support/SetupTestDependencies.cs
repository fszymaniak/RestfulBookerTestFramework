using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;
using Reqnroll.Autofac;
using Reqnroll.Autofac.ReqnrollPlugin;
using RestfulBookerTestFramework.Tests.Commons.Configuration;
using RestfulBookerTestFramework.Tests.Commons.Constants;
using RestfulBookerTestFramework.Tests.Commons.Extensions;
using RestfulBookerTestFramework.Tests.Contracts.Configuration;
using RestfulBookerTestFramework.Tests.Contracts.StepDefinitions;
using ContainerBuilder = Autofac.ContainerBuilder;

namespace RestfulBookerTestFramework.Tests.Contracts.Support;

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
        
        // Drivers
        var projectName = Path.GetFileName(Assembly.GetExecutingAssembly().Location).Split(".dll").First();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load(projectName))
            .Where(t => t.Name.EndsWith("Driver"))
            .AsImplementedInterfaces();
        
        // register binding classes
        containerBuilder.AddReqnrollBindings<CreateTokenSteps>();
        containerBuilder.AddReqnrollBindings<HealthCheckSteps>();
    }
}