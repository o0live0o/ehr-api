using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ehr.Application.Beisen.Recruit.Dtos;
using Ehr.Core.Exceptions;
using Ehr.Core.Utils;
using Ehr.Core.Utils.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Ehr.Application.Beisen.Api
{
    public class ItalentApi
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public ItalentApi(IConfiguration configuration)
        {
            this._configuration = configuration;
            _baseUrl = configuration["Beisen:italent:BaseUrl"];
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        public async Task<BsTokenDto> GetToken()
        {
            RequestContent request = new RequestContent();
            request.FormData.Add("app_id", _configuration["Beisen:OAuth:AppId"]);
            request.FormData.Add("secret", _configuration["Beisen:AppSecret"]);
            request.FormData.Add("tenant_id", _configuration["Beisen:TenantId"]);
            request.FormData.Add("grant_type", _configuration["Beisen:OAuth:GrantType"]);
            request.Url = _configuration["Beisen:OAuth:Url"];
            request.Method = "POST";
            var response = await HttpUtil.SendAsync(request);
            var s = await ByteUtil.Byte2StringAsync(response.Data);
            if (s.Contains("access_token"))
                return JsonConvert.DeserializeObject<BsTokenDto>(s);
            throw new EhrException(HttpStatusCode.BadRequest, s);
        }

        /// <summary>
        /// 创建请求内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpMethod"></param>
        /// <param name="data"></param>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        private async Task<RequestContent> CreateRequestContent(string url, string httpMethod, byte[] data = null, Dictionary<string, object> queryParam = null)
        {
            RequestContent request = new RequestContent();
            request.Url = url;
            request.Method = httpMethod;
            var token = await GetToken();
            request.Headers.Add("Authorization", $"Bearer {token.access_token}");
            request.PostData = data;
            request.Params = queryParam;
            request.ContentType = HttpContentType.APPLICATION_JSON;
            return request;
        }

        #region  Position职务相关
        public async Task AddPosition(BsPositionAddDto position)
        {
            var url = Path.Combine(_baseUrl, "positions");
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(position));
            var request = await CreateRequestContent(url, "POST", data);
            var response = await HttpUtil.SendAsync(request);
            var s = await ByteUtil.Byte2StringAsync(response.Data);
        }
        #endregion

        #region  Organization组织（部门）相关
        public async Task AddOrganization(BsOrganizationAddDto organization)
        {
            var url = Path.Combine(_baseUrl, "departments");
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(organization));
            var request = await CreateRequestContent(url, "POST", data);
            var response = await HttpUtil.SendAsync(request);
            var s = await ByteUtil.Byte2StringAsync(response.Data);
        }
        #endregion

        #region  JobCategory职类（职务类别）相关
        public async Task AddJobCategory(BsJobCategoryAddDto category)
        {
            var url = Path.Combine(_baseUrl, "jobcategories");
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(category));
            var request = await CreateRequestContent(url, "POST", data);
            var response = await HttpUtil.SendAsync(request);
            var s = await ByteUtil.Byte2StringAsync(response.Data);
        }
        #endregion

        /// <summary>
        /// 根据邮件获取员工信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<string> GetStaffByEmail(string email)
        {
            var url = Path.Combine(_baseUrl, "staffs");
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("emails", email);
            var request = await CreateRequestContent(url, "GET", queryParam: dic);
            var response = await HttpUtil.SendAsync(request);
            return await ByteUtil.Byte2StringAsync(response.Data);
        }

    }
}