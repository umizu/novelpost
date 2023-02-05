using MediatR;
using Microsoft.Extensions.DependencyInjection;
using novelpost.Application.Activities;
using novelpost.Application.Services;

namespace novelpost.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        services.AddMediatR(typeof(IApplicationMarker));

        return services;
    }
}
