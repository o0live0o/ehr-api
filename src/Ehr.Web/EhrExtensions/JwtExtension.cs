using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Ehr.Web.EhrExtensions
{
public static class JwtExtension
    {
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                var children = configuration.GetSection("AuthorizationPolicy").GetChildren();
                foreach (var item in children)
                {
                    options.AddPolicy(item.GetValue<string>("Policy"), policy =>
                    {
                        var roles = item.GetSection("Roles").Get<string[]>();
                        policy.RequireRole(roles);
                    });
                }
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = configuration.GetSection("Auth:ValidateIssuer").Get<bool>(),
                    ValidateAudience = configuration.GetSection("Auth:ValidateAudience").Get<bool>(),
                    ValidateLifetime = configuration.GetSection("Auth:ValidateLifetime").Get<bool>(),
                    ValidAudience = configuration["Auth:Audience"],
                    ValidIssuer = configuration["Auth:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}