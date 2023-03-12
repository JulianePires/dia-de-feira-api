using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DiaDeFeira.API.Infraestructure.Swagger
{
    [ExcludeFromCodeCoverage]
    public class SwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public SwaggerOptions(IApiVersionDescriptionProvider provider) =>
            this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Dia de Feira API",
                Version = description.ApiVersion.ToString(),
                Description = "API that provides data for Dia de Feira APP"
            };

            if (description.IsDeprecated)
                info.Description += " This API version has been deprecated.";

            return info;
        }
    }
}
