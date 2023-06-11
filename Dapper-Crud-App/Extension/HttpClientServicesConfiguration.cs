using Dapper_Crud_App.Delegates;
using Dapper_Crud_App.HttpClients;
using Dapper_Crud_App.Options;
using Dapper_Crud_App.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Runtime.CompilerServices;

namespace Dapper_Crud_App.Extension
{
    public static class HttpClientServicesConfiguration
    {
        public static IServiceCollection HttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {

            //var serviceProvider = services.BuildServiceProvider();
            //var databaseConfigurationOptions = serviceProvider.GetRequiredService<IOptions<DatabaseConfigurationOptions>>().Value;
            //var test = databaseConfigurationOptions.ConnectionString;

            services.AddHttpClient();
            services.AddHttpClient<IGitHubClient, GitHubClient>()
                   .ConfigureHttpClient(httpClient =>
                   {
                       httpClient.BaseAddress = new Uri("https://api.github.com/");
                       httpClient.DefaultRequestHeaders.Add(
                       HeaderNames.Accept, "application/vnd.github.v3+json");
                       httpClient.DefaultRequestHeaders.Add(
                                      HeaderNames.UserAgent, "HttpRequestsSample");
                   }).AddHttpMessageHandler<ValidateHeaderHandler>();
            return services;
        }
    }
}
