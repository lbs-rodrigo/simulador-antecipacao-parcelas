using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Simulador.Calculos.Core.Hosting
{
    public static class InjectionCoreExtensions
    {
        public static IServiceCollection AddCommon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();
            services.AddSingleton(configuration);
            return services;
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services, IEnumerable<string> allowOrigins)
        {
            services.AddCors(setup =>
            {
                setup.AddPolicy("simulador_cors", config =>
                {
                    config.WithOrigins(allowOrigins.ToArray())
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });

            return services;
        }

        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers(
                        config =>
                        {
                            config.Filters.Add(new ConsumesAttribute("application/json"));
                            config.Filters.Add(new ProducesAttribute("application/json"));
                        })
                    .AddJsonOptions(
                        config =>
                        {
                            config.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        });

            return services;
        }
    }
}
