﻿using Microsoft.AspNetCore.Http;
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
            if (context.Request.Headers[Constants.CorrelationId].Count == 0)
            {
                var correlationId = Guid.NewGuid().ToString();
                context.Request.Headers[Constants.CorrelationId] = correlationId;
            }

            context.Response.Headers[Constants.CorrelationId] = context.Request.Headers[Constants.CorrelationId];

            if (_next != null)
            {
                await _next(context).ConfigureAwait(false);
            }
        }
    }
}
