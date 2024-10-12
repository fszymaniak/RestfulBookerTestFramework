using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Api.Constants;
using RestfulBookerTestFramework.Tests.Api.Helpers;

using ContainerBuilder = Autofac.ContainerBuilder;
using RestfulBookerTestFramework.Tests.Api.Hooks;
using RestfulBookerTestFramework.Tests.Api.StepDefinitions;

namespace RestfulBookerTestFramework.Tests.Api.Support;

public static class SetupTestDependencies
{
    [GlobalDependencies]
    public static void SetupGlobalContainer(ContainerBuilder containerBuilder)
    {
        // Register globally scoped runtime dependencies
        // Config classes
        containerBuilder
            .RegisterType<AppSettings>()
            .AsSelf()
            .SingleInstance();

        containerBuilder
            .RegisterType<Urls>()
            .AsSelf()
            .SingleInstance();

        containerBuilder
            .RegisterType<Credentials>()
            .AsSelf()
            .SingleInstance();

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

        // RestSharp
        containerBuilder  
            .RegisterType<RestClient>()
            .AsSelf()
            .SingleInstance();

        // Drivers
        var projectName = Path.GetFileName(Assembly.GetExecutingAssembly().Location).Split(".dll").First();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load(projectName))
            .Where(t => t.Name.EndsWith("Driver"))
            .AsImplementedInterfaces();

        // Helpers
        containerBuilder
            .RegisterType<EndpointsHelper>()
            .AsSelf()
            .SingleInstance();
        
        containerBuilder
            .RegisterType<BookingHelper>()
            .AsSelf()
            .SingleInstance();
        
        containerBuilder
            .RegisterType<AuthTokenDriverHelper>()
            .AsSelf()
            .SingleInstance();
        
        containerBuilder
            .RegisterType<AuthTokenRequestHelper>()
            .AsSelf()
            .SingleInstance();
        
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