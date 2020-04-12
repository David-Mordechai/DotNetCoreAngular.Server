using DotNetCoreAngular.Application.DataServices;
using DotNetCoreAngular.Persistence.DataServices;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreAngular.Persistence
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPersistenceLibrary(this IServiceCollection services)
        {
            services.AddDbContext<DotNetCoreAngularDbContext>();
            services.AddTransient<IUserSettingsDataService, UserSettingsDataService>();
            services.AddTransient<IAccountDataService, AccountDataService>();
            services.AddTransient<IRegisterValidatorDataService, RegisterValidatorDataService>();
            return services;
        }
    }
}
