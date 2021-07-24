using Microsoft.Extensions.DependencyInjection;
using Simulador.Calculos.Services;

namespace Simulador.Calculos.Core.Hosting
{
    public static class InjectionServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ParcelasFixasServices>();
            services.AddScoped<AntecipacaoServices>();

            return services;
        }
    }
}
