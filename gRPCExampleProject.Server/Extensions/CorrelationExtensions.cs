using gRPCExampleProject.Server.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace gRPCExampleProject.Server.Extensions
{
    public static class CorrelationExtensions
    {
        public static IApplicationBuilder UseCorrelation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationMiddleware>();
        }
    }
}
