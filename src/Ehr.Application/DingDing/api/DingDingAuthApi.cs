using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Ehr.Application.DingDing.Dtos;
using Ehr.Core.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ehr.Application.DingDing.api
{
    public class DingDingAuthApi : DingDingApi
    {
        public DingDingAuthApi(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        public async Task<(bool succ, DingDingToken token)> GetToken(string appKey,string appSecret)
        {
            DingDingToken token = null;
            bool succ = false;
            var url = Path.Combine(_baseUrl, "gettoken");
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("appkey", appKey);
            param.Add("appsecret", appSecret);
            var request = CreateRequestContent(url, "GET", param);
            var response = await SendAsync(request);
            if (response.Code == 200)
            {
                var str = await ByteUtil.Byte2StringAsync(response.Data);
                token = JsonConvert.DeserializeObject<DingDingToken>(str);
            }
            return (succ, token);
        }
    }
}