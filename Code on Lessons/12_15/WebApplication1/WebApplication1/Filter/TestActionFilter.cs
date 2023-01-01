using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Filter
{
    public class TestActionFilterAttribute: ServiceFilterAttribute
    {
        public TestActionFilterAttribute() : base(typeof(TestActionFilter))
        {
        }
        private class TestActionFilter : IAsyncActionFilter
        {
            private readonly ILogger<TestActionFilter> _logger;
            public TestActionFilter(ILogger<TestActionFilter> logger)
            {
                _logger = logger;
            }
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                Console.WriteLine("beforefilter");
                await next();
                Console.WriteLine("Afterfileter");
            }
        
        }
    }
    
    
}