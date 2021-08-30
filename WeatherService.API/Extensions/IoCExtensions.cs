using Microsoft.Extensions.DependencyInjection;
using WeatherService.API.Contracts;
using WeatherService.API.Repositories;
using WeatherService.API.Services;

namespace WeatherService.API.Extensions
{
    public static class IoCExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, Services.WeatherService>();
            services.AddScoped<ICityService, CityService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWeatherRepository, WeatherRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
        }
    }
}
