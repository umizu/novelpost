using Microsoft.Extensions.DependencyInjection;
using novelpost.Application.Common.Interfaces.Authentication;
using novelpost.Infrastructure.Authentication;

namespace novelpost.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}
