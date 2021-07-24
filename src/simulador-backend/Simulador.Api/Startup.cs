using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simulador.Calculos.Core.Hosting;
using Simulador.Calculos.Core.Middleware;
using Simulador.Calculos.Core.Swagger;

namespace Simulador.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCommon(Configuration);
            services.AddServices();
            services.AddCustomCors(new string[] { "http://localhost" });
            services.AddCustomControllers();
            services.AddDoc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(error => error.UseCustomErrors());
            app.UseDoc();
            app.UseRouting();
            app.UseCors("simulador_cors");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
