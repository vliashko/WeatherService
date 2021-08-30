using WeatherService.API.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace WeatherService.API.Extensions
{
    public static class CorrelationExtensions
    {
        public static IApplicationBuilder UseCorrelation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationMiddleware>();
        }
    }
}
