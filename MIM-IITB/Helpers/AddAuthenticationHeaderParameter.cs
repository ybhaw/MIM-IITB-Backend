using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MIM_IITB.Helpers
{
    public class AddAuthenticationHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters = new List<OpenApiParameter>
            {
                new OpenApiParameter
                {
                    Name = "authorize",
                    In = ParameterLocation.Header,
                    Description = "Token to grant access",
                    Required = false,
                    Schema = new OpenApiSchema {Type = "String"}
                }
            };
        }
    }
}