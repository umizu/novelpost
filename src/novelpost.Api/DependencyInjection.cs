using novelpost.Api.Common.Mapping;

namespace novelpost.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddControllers();
        services.AddHttpContextAccessor();
        return services;
    }
}
