using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Middleware
{
    public class ConventinalMiddle
    {
        private readonly RequestDelegate _next;
        public ConventinalMiddle(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<ConventinalMiddle> logger)
        {
            context.Response.StatusCode = 404;
            
            await _next(context);
            
            logger.LogInformation("After");
        }

    }
}