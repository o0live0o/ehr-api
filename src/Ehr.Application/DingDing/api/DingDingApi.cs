using System.Collections.Generic;
using System.Threading.Tasks;
using Ehr.Core.Utils;
using Ehr.Core.Utils.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ehr.Application.DingDing.api
{
    public class DingDingApi
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        protected static string _baseUrl { get; set; }

        public DingDingApi(IConfiguration configuration, ILogger logger)
        {
            this._configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
            this._logger = logger ?? throw new System.ArgumentNullException(nameof(logger));

            _baseUrl = _configuration["DingDing:Url:BaseUrl"];
        }

        protected RequestContent CreateRequestContent(string url, string httpMethod,
                                                      Dictionary<string, object> param = null,
                                                      Dictionary<string, object> form = null)
        {
            RequestContent request = new RequestContent();
            request.Url = url;
            request.Method = httpMethod;
            request.Params = param;
            request.FormData = form;
            return request;
        }

        protected async Task<ResponseContent> SendAsync(RequestContent request)
        {
            var resp = await HttpUtil.SendAsync(request);
            var msg = await ByteUtil.Byte2StringAsync(resp.Data);
            var formData = request.FormData == null ? "" : JsonConvert.SerializeObject(request.FormData);
            _logger.LogInformation($"[{request.Url}({formData})]{msg.Replace("\r", "").Replace("\n", "")}");
            return resp;
        }
    }
}