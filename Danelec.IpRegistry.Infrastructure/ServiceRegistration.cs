using Danelec.IpRegistry.Core.Interfaces;
using Danelec.IpRegistry.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Danelec.IpRegistry.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<IpRegistryContext>();
        services.AddTransient<IIpRegistry, Data.IpRegistry>();
        return services;
    }
}