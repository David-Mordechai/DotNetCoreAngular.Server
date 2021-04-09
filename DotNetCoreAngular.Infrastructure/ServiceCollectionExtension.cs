using AutoMapper;
using DotNetCoreAngular.Application.Auth;
using DotNetCoreAngular.Application.Services;
using DotNetCoreAngular.Infrastructure.Auth;
using DotNetCoreAngular.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DotNetCoreAngular.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureLibrary(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserSettingsService, UserSettingsService>();
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
