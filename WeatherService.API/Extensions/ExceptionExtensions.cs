using WeatherService.API.Infrastructure;
using Microsoft.AspNetCore.Builder;
using System;

namespace WeatherService.API.Extensions
{
    public static class ExceptionExtensions
    {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationMiddleware>();
        }

        public static string GetFullMessage(this Exception ex)
        {
            if (ex == null)
            {
                return "Exception message is empty";
            }

            return ex.Message + "; " + ex.InnerException?.GetFullMessage();
        }
    }
}
