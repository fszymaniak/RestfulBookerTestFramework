using System.Reflection;
using Autofac;
using RestfulBookerTestFramework.Tests.Api.Configuration;
using RestfulBookerTestFramework.Tests.Commons.Configuration;
using RestfulBookerTestFramework.Tests.Commons.Helpers;
using RestSharp;

namespace RestfulBookerTestFramework.Tests.Commons.Extensions;

public static class DependencyExtensions
{
    public static void AddCommonDependenciesGlobalContainer(this ContainerBuilder containerBuilder)
    {
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
    }
    
    public static void AddCommonDependenciesScenarioContainer(this ContainerBuilder containerBuilder)
    {
        // Drivers
        var projectName = Path.GetFileName(Assembly.GetExecutingAssembly().Location).Split(".dll").First();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load(projectName))
            .Where(t => t.Name.EndsWith("Driver"))
            .AsImplementedInterfaces();
        
        // RestSharp
        containerBuilder  
            .RegisterType<RestClient>()
            .AsSelf()
            .SingleInstance();

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
    }
}