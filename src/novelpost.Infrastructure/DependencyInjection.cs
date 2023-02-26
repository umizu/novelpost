using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using novelpost.Application.Common.Interfaces.Authentication;
using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Application.Common.Interfaces.Services;
using novelpost.Infrastructure.Authentication;
using novelpost.Infrastructure.Persistence.Repositories;
using novelpost.Infrastructure.Services;

namespace novelpost.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        // services.AddDbContext<DataContext>(o => o.UseSqlite(configuration.GetValue<string>("Database:ConnectionString")));

        services.AddScoped<IUserRepository, UserRepository>();

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        return services;
    }
}
