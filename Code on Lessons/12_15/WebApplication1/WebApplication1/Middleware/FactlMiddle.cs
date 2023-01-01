using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Middleware
{
    public class FactMiddle : IMiddleware
    {
        private readonly ILogger<FactMiddle> _logger;
        public FactMiddle(ILogger<FactMiddle> logger)
        {
            _logger = logger;
        }

        async public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
            _logger.LogInformation("After");
        }
        
    }
}