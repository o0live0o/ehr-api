using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Ehr.Core.ExtendMethods;
using Ehr.Core.Utils;
using Ehr.Core.Utils.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ehr.Application.Beisen.Api
{
    /// <summary>
    /// 应聘者
    /// </summary>
    public class ApplicantApi : BeisenApi
    {
        public ApplicantApi(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        /// <summary>
        /// 北森 3.1.2 根据时间戳(转移时间)获取指定阶段状态下的应聘者ID列表
        /// </summary>
        /// <param name="succ"></param>
        /// <param name="startTime">开始时间 yyyyMMddhhmmss</param>
        /// <param name="endTime">结束时间 yyyyMMddhhmmss</param>
        /// <param name="statusId">状态编码（Uxx）</param>
        /// <param name="phaseId">阶段编码（Sxx）</param>
        /// <returns></returns>
        public async Task<(bool succ, IEnumerable<string> ids)> GetApplicantIdsByDateAndStatus(string startTime, string endTime, string statusId, string phaseId)
        {
            List<string> list = null;
            bool succ = false;
            var url = Path.Combine(_baseUrl, nameof(GetApplicantIdsByDateAndStatus));
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("start_time", startTime);
            param.Add("end_time", endTime);
            param.Add("status_id", statusId);
            param.Add("phase_id", phaseId);
            var request = CreateRequestContent(url, "GET", param, action: nameof(GetApplicantIdsByDateAndStatus));
            var response = await SendAsync(request);
            if (response.Code == 200)
            {
                var str = await ByteUtil.Byte2StringAsync(response.Data);
                list = JsonConvert.DeserializeObject<List<string>>(str);
                succ = !str.RegexIsMatch("<error_code>(.*)</error_code>");
            }
            return (succ, list);
        }

        /// <summary>
        /// 北森3.1.13 根据应聘者id获取应聘者标准简历（源数据）
        /// </summary>
        /// <param name="succ"></param>
        /// <param name="personids">应聘者id 英文逗号隔开，最多100个</param>
        /// <param name="hasLong">是否为长链接 默认为长链接，可以忽略不传。1表示长链接，2表示短连接</param>
        /// <returns></returns>
        public async Task<(bool succ, string data)> GetApplicantProfileById(string[] personids, string hasLong = "1")
        {
            bool succ = false;
            string data = null;
            var url = Path.Combine(_baseUrl, nameof(GetApplicantProfileById));
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("personids", string.Join(',', personids));
            param.Add("has_Long", hasLong);
            var request = CreateRequestContent(url, "GET", param, action: nameof(GetApplicantProfileById));
            var response = await SendAsync(request);
            if (response.Code == 200)
            {
                data = await ByteUtil.Byte2StringAsync(response.Data);
                succ = !data.RegexIsMatch("<error_code>(.*)</error_code>");
            }
            return (succ, data);
        }
    }
}