using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreAngular.Persistence
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPersistenceLibrary(this IServiceCollection services)
        {
            services.AddDbContext<DotNetCoreAngularDbContext>();
            return services;
        }
    }
}
