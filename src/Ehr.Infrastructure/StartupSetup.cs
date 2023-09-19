using Ehr.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ehr.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddEhrDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EhrDbContext>(options => {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging(true);
            
            });
        }
    }
}