using Ehr.Core.Data.Models;
using Ehr.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ehr.Core.Aop
{
    public class EhrGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var json = new JsonErrorResponse();
            json.TraceId = context.HttpContext.TraceIdentifier;

            if (context.Exception is EhrException wxException)
            {
                json.Message = wxException.Message;
                json.Title = wxException.GetStatusCode().ToString();
                context.Result = new ObjectResult(json) { StatusCode = wxException.GetCode() };
                json.Code = wxException.GetCode();
            }
            else
            {
                json.DeveloperMessage = context.Exception;
                context.Result = new ObjectResult(json) { StatusCode = StatusCodes.Status500InternalServerError };
            }

            context.ExceptionHandled = true;
        }
    }
}