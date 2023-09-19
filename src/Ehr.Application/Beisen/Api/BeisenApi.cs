using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using Ehr.Core.ExtendMethods;
using Ehr.Core.Utils;
using Ehr.Core.Utils.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ehr.Application.Beisen.Api
{
    public class BeisenApi
    {
        private readonly IConfiguration _configuration;
        protected readonly ILogger _logger;
        protected readonly string _token;
        protected readonly string _baseUrl;

        public BeisenApi(IConfiguration configuration, ILogger logger)
        {
            this._configuration = configuration;
            this._logger = logger;
            _token = configuration["Beisen:Token"];
            _baseUrl = configuration["Beisen:BaseUrl"];
        }

        protected RequestContent CreateRequestContent(string url,
                                                      string httpMethod,
                                                      Dictionary<string, object> param = null,
                                                      Dictionary<string, object> form = null,
                                                      string action = null)
        {
            RequestContent request = new RequestContent();
            request.Url = url;
            request.Action = action;
            request.Method = httpMethod;
            request.Params = param;
            request.Headers.Add("Authorization", $"Bearer {_token}");
            request.Host = "api.beisenapp.com";
            request.FormData = form;
            return request;
        }

        protected async Task<ResponseContent> SendAsync(RequestContent request)
        {
            ResponseContent resp = null;

#if DEBUG
            resp = new ResponseContent();
            resp.Code = 200;
            resp.Data = File.ReadAllBytes($"TestData/{request.Action}.txt");
#else
            resp = await HttpUtil.SendAsync(request);
#endif

            #region 记录API请求日志
            var msg = await ByteUtil.Byte2StringAsync(resp.Data);
            var formData = request.FormData == null ? "" : JsonConvert.SerializeObject(request.FormData);
            _logger.LogInformation($"[{request.Url}({formData})]{msg.Replace("\r", "").Replace("\n", "")}");
            #endregion

            return resp;
        }

    }
}