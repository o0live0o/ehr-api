using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Ehr.Web.EhrExtensions
{
    public static class SwaggerExtension
    {
        public static List<(string GroupName, ApiVersion Version)> ApiDocs = new List<(string GroupName, ApiVersion Version)>();

        public static void AddSwagerApiVersion(this IServiceCollection services)
        {

            var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
            foreach (var description in provider.ApiVersionDescriptions)
            {
                ApiDocs.Add((description.GroupName, description.ApiVersion));
            }

            services.AddSwaggerGen(c =>
            {
                foreach (var doc in ApiDocs)
                {
                    c.SwaggerDoc(doc.GroupName, new OpenApiInfo
                    {
                        Title = $"v{doc.Version}",
                        Version = doc.Version.ToString(),
                    });
                }
                var xmlPath = Path.Combine(System.AppContext.BaseDirectory, "ehr-api.xml");
                c.IncludeXmlComments(xmlPath, true);

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权 Bearer {token}",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });
            });
        }
    }
}