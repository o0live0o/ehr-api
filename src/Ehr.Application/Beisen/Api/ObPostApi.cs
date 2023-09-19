using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Ehr.Application.Beisen.Sync;
using Ehr.Application.Beisen.Sync.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ehr.Application.Beisen.Api
{
    /// <summary>
    /// 应用岗位
    /// </summary>
    public class ObPostApi : BeisenApi
    {
        private readonly IConfiguration _configuration;

        public ObPostApi(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// 北森 3.15.2 更新ob岗位
        /// </summary>
        /// <param name="postDto"></param>
        /// <returns></returns>
        public async Task<ObPostRespDto> UpdateObPost(ObPostDto postDto)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("tenant_id", postDto.tenant_id);
            dic.Add("UpdateEmail", postDto.CreateEmail);
            dic.Add("Name", postDto.Name);
            dic.Add("Org", postDto.Org);
            dic.Add("id", postDto.id);
            var url = Path.Combine(_configuration["Beisen:ObBaseUrl"], "UpdateObPost");
            var request = CreateRequestContent(url, "POST", form: dic, action: "UpdateObPost");
            var response = await SendAsync(request);
            ObPostRespDto resp = null;
            if (response.Code == 200)
                resp = JsonConvert.DeserializeObject<ObPostRespDto>(response.DataString);
            else
            {
                resp = new ObPostRespDto();
                resp.Code = "5001";
                resp.Description = response.DataString;
            }
            return resp;
        }

    }
}