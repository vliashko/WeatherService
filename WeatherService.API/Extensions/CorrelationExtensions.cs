using WeatherService.API.Server.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace WeatherService.API.Server.Extensions
{
    public static class CorrelationExtensions
    {
        public static IApplicationBuilder UseCorrelation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationMiddleware>();
        }
    }
}
