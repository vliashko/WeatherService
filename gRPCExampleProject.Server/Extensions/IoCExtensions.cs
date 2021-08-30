using gRPCExampleProject.Server.Contracts;
using gRPCExampleProject.Server.Repositories;
using gRPCExampleProject.Server.Services;
using Microsoft.Extensions.DependencyInjection;

namespace gRPCExampleProject.Server.Extensions
{
    public static class IoCExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWeatherRepository, WeatherRepository>();
        }
    }
}
