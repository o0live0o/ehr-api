using System;

namespace Ehr.Core.Data.Models
{
    public class JsonErrorResponse
    {
        public string Message { get; set; }

        public object DeveloperMessage { get; set; }

        public int Code { get; set; } = 500;

        public string Title { get; set; } = "Internal Server Error";

        public string TraceId { get; set; }

        public string _t { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }
}