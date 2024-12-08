using System.Reflection;
using Autofac;

namespace RestfulBookerTestFramework.Tests.Commons.Extensions;

public static class DependencyExtensions
{
    public static void AddCommonDependencies(this ContainerBuilder containerBuilder)
    {
        // Drivers
        var projectName = Path.GetFileName(Assembly.GetExecutingAssembly().Location).Split(".dll").First();
        containerBuilder.RegisterAssemblyTypes(Assembly.Load(projectName))
            .Where(t => t.Name.EndsWith("Driver"))
            .AsImplementedInterfaces();
    }
}