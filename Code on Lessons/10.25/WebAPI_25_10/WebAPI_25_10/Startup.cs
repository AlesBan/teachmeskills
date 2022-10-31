using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_25_10.Interfaces;

namespace WebAPI_25_10
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services, IOptions<ComplexSetting> complexSets)
        {
            services.AddControllers();
            services.AddOpenApiDocument(config =>
            {
                config.Title = "My best site";
            });

            services.AddScoped<IHomeService, HomeService>();

            services.Configure<ComplexSetting>(_configuration.GetSection(ComplexSetting.ConfigPath));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();



            app.UseOpenApi();
            app.UseSwaggerUi3(config =>
            {
                config.DocumentTitle = "MY NEW TITLE";
                config.DocExpansion = "list";

            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    
}
