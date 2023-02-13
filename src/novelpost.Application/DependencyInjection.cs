using MediatR;
using Microsoft.Extensions.DependencyInjection;
using novelpost.Application.Activities;
using novelpost.Application.Services.Authentication;
using novelpost.Application.Services.Authentication.Commands;
using novelpost.Application.Services.Authentication.Queries;

namespace novelpost.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthQueryService, AuthQueryService>();
        services.AddScoped<IAuthCommandService, AuthCommandService>();

        services.AddMediatR(typeof(IApplicationMarker));

        return services;
    }
}
