using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Autofac;
using Ehr.Application;
using Ehr.Application.Profiles;
using Ehr.Core.Aop;
using Ehr.Core.Base;
using Ehr.Infrastructure;
using Ehr.Web.AutofacModule;
using Ehr.Web.EhrExtensions;
using Ehr.Web.Filters;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Ehr.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(EhrGlobalExceptionFilter));
            }).AddNewtonsoftJson();
            services.AddAutoMapper(typeof(RecruitProfile).Assembly);
            services.AddApiVersion(Configuration);
            services.AddJwt(Configuration);
            services.AddSwagerApiVersion();
            services.AddEhrDbContext(Configuration["Database:ConnectString"]);
            services.AddEhrHangfire(Configuration);
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IEhrUserInfo, EhrUserInfo>();
            services.AddIpRateLimiting(Configuration);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var doc in SwaggerExtension.ApiDocs)
                {
                    c.SwaggerEndpoint($"/swagger/{doc.GroupName}/swagger.json", doc.GroupName.ToUpperInvariant());
                }
            });
            EhrServiceProvider.Instance = app.ApplicationServices;

            app.UseSerilogRequestLogging();

            var origins = Configuration.GetSection("Origins").Get<string[]>();
            // app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(origins));
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(_ => true));
            
            app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseApiVersioning();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new EhrDashboardAuthorizationFilter(Configuration) }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
