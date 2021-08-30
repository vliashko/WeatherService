using WeatherService.API.Contracts;
using WeatherService.API.Repositories;
using WeatherService.API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherService.API.Extensions
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
