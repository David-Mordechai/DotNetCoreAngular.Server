using DotNetCoreAngular.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreAngular.Application
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLibrary(this IServiceCollection services)
        {
            services.AddTransient<IRegisterValidator, RegisterValidator>();
        }
    }
}
