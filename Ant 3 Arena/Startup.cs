using Ant3Arena.Application;
using Ant3Arena.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ant_3_Arena;

public static class Startup
{
    public static ServiceProvider ConfigureServices()
    {
        ServiceCollection services = new ServiceCollection();

        services.AddLogging(config =>
        {
            config.AddDebug();
            config.SetMinimumLevel(LogLevel.Information);
        });

        services.AddInfrastructure();
        services.AddApplication();

        services.AddScoped<AntArena>();

        return services.BuildServiceProvider();
    }
}

