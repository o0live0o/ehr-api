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
    public class OfferApi : BeisenApi
    {
        public OfferApi(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        /// <summary>
        /// 北森 3.2.9 根据应聘者id获取应聘者申请信息
        /// </summary>
        /// <param name="succ"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<(bool succ, string data)> GetNewApplyInfosAsync(string[] ids)
        {
            bool succ = false;
            string data = null;

            var url = Path.Combine(_baseUrl, nameof(GetNewApplyInfosAsync).Replace("Async", ""));
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("person_ids", string.Join(',', ids));

            var request = CreateRequestContent(url, "GET", param, action: nameof(GetNewApplyInfosAsync).Replace("Async", ""));

            var response = await SendAsync(request);
            if (response.Code == 200)
            {
                data = await ByteUtil.Byte2StringAsync(response.Data);
                succ = !data.RegexIsMatch("<error_code>(.*)</error_code>");
            }
            return (succ, data);
        }

        /// <summary>
        /// 北森 3.5.5. ob应用--根据应聘者id和职位id 获取审批通过的offer审批
        /// </summary>
        /// <param name="succ"></param>
        /// <param name="persionId">申请人北森id</param>
        /// <param name="jobId">申请人北森岗位id</param>
        /// <returns></returns>
        public async Task<(bool succ, string data)> GetOBOfferApplyByPersonAsync(int persionId, int jobId)
        {
            bool succ = false;
            string data = null;

            var url = Path.Combine(_baseUrl, nameof(GetOBOfferApplyByPersonAsync).Replace("Async", ""));
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("person_id", persionId);
            param.Add("job_id", jobId);

            var request = CreateRequestContent(url, "GET", param, action: nameof(GetOBOfferApplyByPersonAsync).Replace("Async", ""));

            var response = await SendAsync(request);
            if (response.Code == 200)
            {
                data = await ByteUtil.Byte2StringAsync(response.Data);
                succ = !data.RegexIsMatch("<error_code>(.*)</error_code>");
            }
            return (succ, data);
        }

        /// <summary>
        /// 北森3.2.4 更新应聘者所在职位的阶段状态或将应聘者储备到某人才库
        /// </summary>
        /// <param name="succ"></param>
        /// <param name="persionId"></param>
        /// <param name="jobId"></param>
        /// <param name="phaseId">阶段编码（Sxx）</param>
        /// <param name="statusId">	状态编码（Uxx）</param>
        /// <returns></returns>
        public async Task<(bool succ, string data)> ConToJobOrStorsDBAsync(string persionId, string jobId, string phaseId, string statusId)
        {
            bool succ = false;
            string data = null;

            var url = Path.Combine(_baseUrl, nameof(ConToJobOrStorsDBAsync).Replace("Async", ""));
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("applicant_ids", persionId);
            param.Add("job_id", jobId);
            param.Add("phase_id", phaseId);
            param.Add("status_id", statusId);

            var request = CreateRequestContent(url, "POST", form: param, action: nameof(ConToJobOrStorsDBAsync).Replace("Async", ""));

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