using Microsoft.Extensions.DependencyInjection;
using Ant3Arena.Application;
using Ant3Arena.Infrastructure;

namespace Ant_3_Arena;

public static class Startup
{
    public static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Adiciona os módulos
        services.AddInfrastructure();
        services.AddApplication(); 

        // Adiciona a UI (form principal)
        services.AddScoped<AntArena>();

        return services.BuildServiceProvider();
    }
}

