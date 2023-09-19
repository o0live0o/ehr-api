using Microsoft.AspNetCore.Http;
using Serilog;

namespace Ehr.Web.EhrExtensions
{
    public static class LogExtension
    {
        public static void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
        {
        }
    }
}