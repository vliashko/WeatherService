using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace gRPCExampleProject.Server.Infrastructure
{
    public class CorrelationMiddleware
    {
        private readonly RequestDelegate _next;

        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers[Constants.CORRELATION_ID].Count == 0)
            {
                var correlationId = Guid.NewGuid().ToString();
                context.Request.Headers[Constants.CORRELATION_ID] = correlationId;
            }

            context.Response.Headers[Constants.CORRELATION_ID] = context.Request.Headers[Constants.CORRELATION_ID];

            if (_next != null)
            {
                await _next(context).ConfigureAwait(false);
            }
        }
    }
}
