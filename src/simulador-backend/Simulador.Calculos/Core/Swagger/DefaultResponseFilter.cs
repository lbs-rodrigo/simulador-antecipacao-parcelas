using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Simulador.Calculos.Core.Swagger
{
    /// <summary>
    /// Adiciona o padrão de erros na documentação do swagger
    /// </summary>
    public class DefaultResponseFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation = BuildError400(operation, context);
            operation = BuildError401(operation, context);
            operation = BuildError403(operation, context);
            operation = BuildError500(operation, context);
            operation = BuildCommonErrorResponse(operation, context);
        }

        private OpenApiOperation BuildError400(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Responses.Add("400", new OpenApiResponse
            {
                Description = "Não será possivel processar a requisição devido a algum erro nos dados.",
            });

            return operation;
        }

        private OpenApiOperation BuildError401(OpenApiOperation operation, OperationFilterContext context)
        {
            var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<AuthorizeAttribute>();

            if (authAttributes.Any())
                operation.Responses.Add("401", new OpenApiResponse
                {
                    Description = "Acesso não autorizado, token inválido.",
                });

            return operation;
        }

        private OpenApiOperation BuildError403(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Responses.Add("403", new OpenApiResponse
            {
                Description = "O token informado não possui acesso para processar a requisição.",
            });

            return operation;
        }

        private OpenApiOperation BuildError500(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Responses.Add("500", new OpenApiResponse
            {
                Description = "Ocorreu algum erro não tratado, entre em contato com os desenolvedores",
            });

            return operation;
        }

        private OpenApiOperation BuildCommonErrorResponse(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Responses.Add("400, 403 e 500", new OpenApiResponse
            {
                Description = "Padrão de resposta para mensagens de erro.",
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    { "application/json", new OpenApiMediaType
                        {
                            Example = OpenApiAnyFactory
                                        .CreateFromJson(JsonSerializer.Serialize(new { message = "Informações sobre o erro." }))

                        }
                    }
                }
            });

            return operation;
        }
    }
}
