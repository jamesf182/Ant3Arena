using Ant3Arena.Application.Factory;
using Ant3Arena.Application.Interfaces;
using Ant3Arena.Application.Services;
using Ant3Arena.Domain.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Ant3Arena.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAntService, AntService>();
        services.AddScoped<IAntFactory, AntFactory>();

        return services;
    }
}
