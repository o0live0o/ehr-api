using System.Collections.Generic;

namespace Ehr.Core.Utils.Http
{
    public class RequestContent
    {
        public string Url { get; set; }      
        public string Action { get; set; }

        public string ContentType { get; set; }

        public string Method { get; set; } = "GET";

        public int Timeout { get; set; } = 20000;

        public bool AllowRedirect { get; set; } = true;

        public byte[] PostData { get; set; }

        public Dictionary<string, object> Params { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> Cookies { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> Headers { get; set; } = new Dictionary<string, object>();
        public string Referer { get; set; }
        public Dictionary<string, object> FormData { get; set; } = new Dictionary<string, object>();
        public string Host { get; set; }
    }
}