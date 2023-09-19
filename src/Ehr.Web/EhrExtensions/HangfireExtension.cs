using System.Linq;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ehr.Web.EhrExtensions
{
    public static class HangfireExtension
    {
        public static void AddEhrHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(options =>
                            options.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                            .UseSimpleAssemblyNameTypeSerializer()
                            .UseRecommendedSerializerSettings()
                        );
            GlobalConfiguration.Configuration.UseStorage(new SqlServerStorage(configuration["Hangfire:ConnectString"]));
            services.AddHangfireServer(action =>
            {
                action.ServerName = configuration["Hangfire:ServerName"];
                action.Queues = configuration.GetSection("Hangfire:Queues").Get<string[]>();
            });
        }
    }
}