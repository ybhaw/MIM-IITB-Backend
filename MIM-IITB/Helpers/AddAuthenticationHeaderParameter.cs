using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MIM_IITB.Helpers
{
    public class AddAuthenticationHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if(operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "authorize",
                In = ParameterLocation.Header,
                Description = "Token to grant access",
                Required = false,
                Schema = new OpenApiSchema {Type = "String"}
            });
        }
    }
}