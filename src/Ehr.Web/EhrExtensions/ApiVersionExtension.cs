using Ehr.Core.ExtendMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ehr.Web.EhrExtensions
{
    public static class ApiVersionExtension
    {
        public static void AddApiVersion(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(
                    configuration["ApiVersion:DefaultMajorVersion"].ToInt(),
                    configuration["ApiVersion:DefaultMinorVersion"].ToInt());
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader(configuration["ApiVersion:HeaderName"])
                    );
            });

            services.AddVersionedApiExplorer(option =>
            {
                option.GroupNameFormat = "'v'V";
                option.AssumeDefaultVersionWhenUnspecified = true;
            });
        }
    }
}