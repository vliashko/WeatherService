using WeatherService.API.Server.Contracts;
using WeatherService.API.Server.Repositories;
using WeatherService.API.Server.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherService.API.Server.Extensions
{
    public static class IoCExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, Services.WeatherService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWeatherRepository, WeatherRepository>();
        }
    }
}
