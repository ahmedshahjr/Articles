using Dapper_Crud_App.Delegates;
using Dapper_Crud_App.Options;
using Dapper_Crud_App.Repository.Implementation;
using Dapper_Crud_App.Repository.Infrastructure;
using Dapper_Crud_App.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Dapper_Crud_App.Extension
{
    public static class ScopedServicesConfiguration
    {
        public static IServiceCollection ScopeServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
        public static IServiceCollection SingletonsServices(this IServiceCollection services)
        {
            services.AddScoped<IDapperUserRepository, DapperUserRepository>();
            services.AddScoped<IDapperFastCrudUserRepository, DapperFastCrudUserRepository>();

            return services;
        }
        public static IServiceCollection TransientsServices(this IServiceCollection services)
        {
            services.AddTransient<ValidateHeaderHandler>();
            return services;
        }
        public static IServiceCollection AddOptionsServices(this IServiceCollection services)
        {
            services.AddOptions<DatabaseConfigurationOptions>()
                    .BindConfiguration(DatabaseConfigurationOptions.DatabaseConfiguration)
                    .ValidateDataAnnotations();
            return services;
        }
    }
}
