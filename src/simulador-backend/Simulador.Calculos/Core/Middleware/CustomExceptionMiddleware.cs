using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace Simulador.Calculos.Core.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<CustomExceptionMiddleware> _log)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            await context
                    .Response
                    .WriteAsync(JsonSerializer.Serialize(new { message = "Ocorreu algum erro inexperado" }));

            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();

            _log.LogError(exceptionHandlerPathFeature.Error.ToString());
        }
    }
}
