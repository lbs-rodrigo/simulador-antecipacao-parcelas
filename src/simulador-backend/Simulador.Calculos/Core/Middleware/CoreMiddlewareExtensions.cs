using Microsoft.AspNetCore.Builder;

namespace Simulador.Calculos.Core.Middleware
{
    public static class CoreMiddlewareExtensions
    {
        public static void UseCustomErrors(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
