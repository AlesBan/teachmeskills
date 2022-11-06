using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_10._27DZ.Helpers;
using Web_10._27DZ.Interfaces;
using Web_10._27DZ.PersonEnv;
using WebAPI_10._25DZ.DI;

namespace Web_10._27DZ
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApiDocument(config =>
            {
                config.Title = "My best site";
            });

            services.AddSingleton<IJsonIteractor, JsonIteractor>();
            services.AddSingleton<IPeopleStorage, PeopleStorage>();
        }

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
                config.DocumentTitle = " Web_10._27DZ";
                config.DocExpansion = "list";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
