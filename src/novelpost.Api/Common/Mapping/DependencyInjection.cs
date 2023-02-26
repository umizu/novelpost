using Mapster;
using MapsterMapper;

namespace novelpost.Api.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
        config.Scan(typeof(DependencyInjection).Assembly);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}
