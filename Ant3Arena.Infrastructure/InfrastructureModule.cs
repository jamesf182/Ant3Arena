using Ant3Arena.Domain.Repository;
using Ant3Arena.Infrastructure.FileSystem;
using Ant3Arena.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Ant3Arena.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAntRepository, AntRepository>();
        services.AddScoped<IFileReader, FileReader>();

        return services;
    }
}
