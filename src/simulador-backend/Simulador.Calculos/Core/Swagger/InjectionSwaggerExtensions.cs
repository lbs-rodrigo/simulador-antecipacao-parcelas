using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Simulador.Calculos.Core.Swagger
{
    public static class InjectionSwaggerExtensions
    {
        /// <summary>
        /// Adiciona o swagger e customiza a url de acesso
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                setup =>
                {
                    setup.SwaggerDoc("api-docs", new OpenApiInfo
                    {
                        Title = "API Simulação Empréstimos",
                        Description = "API responsável por realizar as simulações."

                    });

                    setup.OperationFilter<DefaultResponseFilter>();

                    IncludeAllXmls(setup);
                });
            return services;
        }

        /// <summary>
        /// Inclui todos os arquivos xml que contem os comentarios(summary)
        /// </summary>
        /// <param name="setup"></param>
        private static void IncludeAllXmls(SwaggerGenOptions setup)
        {
            List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml").ToList();
            foreach (string xml in xmlFiles)
                setup.IncludeXmlComments(xml);
        }

        /// <summary>
        /// Customizaa o caminho do arquivo swagger.json para o novo endpoint
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseDoc(this IApplicationBuilder app)
        {
            app.UseSwagger(setup =>
            {
                setup.RouteTemplate = "{documentName}/swagger.json";
            });

            app.UseSwaggerUI(
                setup =>
                {
                    setup.SwaggerEndpoint($"swagger.json", "api-docs");
                    setup.DocumentTitle = "API Docs";
                    setup.RoutePrefix = "api-docs";
                });
            return app;
        }
    }
}
