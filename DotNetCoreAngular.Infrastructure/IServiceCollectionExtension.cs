using AutoMapper;
using DotNetCoreAngular.Application.Services;
using DotNetCoreAngular.Application.Validators;
using DotNetCoreAngular.Infrastructure.Services;
using DotNetCoreAngular.Infrastructure.Validators;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DotNetCoreAngular.Infrastructure
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureLibrary(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IUserSettingsService, UserSettingsService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IRegisterValidator, RegisterValidator>();
            return services;
        }
    }
}
