using System;
using System.Diagnostics.CodeAnalysis;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Ehr.Web.Filters
{
    public class EhrDashboardAuthorizationFilter: IDashboardAuthorizationFilter
    {
        private readonly IConfiguration _configurarion;

        private string _userName;
        private string _pwd;

        public EhrDashboardAuthorizationFilter(IConfiguration configurarion)
        {
            this._configurarion = configurarion ?? throw new ArgumentNullException(nameof(configurarion));
            _userName = configurarion["Hangfire:User"];
            _pwd = configurarion["Hangfire:Pwd"];
        }

        public bool Authorize([NotNull] DashboardContext context)
        {

            var httpContext = context.GetHttpContext();

            var header = httpContext.Request.Headers["Authorization"];

            if (!string.IsNullOrWhiteSpace(header))
            {
                var authValues = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(header);

                if ("Basic".Equals(authValues.Scheme, StringComparison.InvariantCultureIgnoreCase))
                {
                    var parameter = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authValues.Parameter));
                    var parts = parameter.Split(':');

                    if (parts.Length > 1)
                    {
                        var username = parts[0];
                        var password = parts[1];

                        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                        {
                            if (username == _userName && password == _pwd)
                            {
                                return true;
                            }
                            return Challenge(httpContext);
                        }
                    }
                }
            }
            return Challenge(httpContext);
        }

        private bool Challenge(HttpContext httpContext)
        {
            if (!httpContext.Response.HasStarted)
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.Headers.Append("WWW-Authenticate", "Basic realm=\"Hangfire Dashboard\"");
            }
            return false;
        }
    }
}