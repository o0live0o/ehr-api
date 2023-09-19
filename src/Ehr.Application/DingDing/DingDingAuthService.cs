using System.Threading.Tasks;
using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using Ehr.Application.DingDing.api;
using Ehr.Application.DingDing.Dtos;
using Ehr.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static DingTalk.Api.Response.OapiV2UserGetuserinfoResponse;

namespace Ehr.Application.DingDing
{
    public class DingDingAuthService
    {
        private readonly IConfiguration _configruation;
        private readonly ILogger<DingDingAuthService> _logger;

        public DingDingAuthService(IConfiguration configruation, ILogger<DingDingAuthService> logger)
        {
            this._configruation = configruation;
            this._logger = logger;
        }

        public async Task<UserGetByCodeResponseDomain> DingDingLoginAsync(string appName, string code)
        {
            var token = await GetAccessToken(appName);
            if (token?.errcode != "0")
                throw new EhrException(System.Net.HttpStatusCode.BadRequest, token == null ? "获取token失败" : JsonConvert.SerializeObject(token));
            var userInfo = GetUserInfo(code, token.access_token);
            if (userInfo.Errcode != 0)
            {
                _logger.LogError($"登录失败: {JsonConvert.SerializeObject(userInfo)}");
                throw new EhrException(System.Net.HttpStatusCode.BadRequest, "钉钉登录失败,请联系管理员!");
            }
            return userInfo.Result;
        }

        public async Task<DingDingToken> GetAccessToken(string appName)
        {
            var appKey = _configruation[$"DingDing:App:{appName}:AppKey"];
            var appSecret = _configruation[$"DingDing:App:{appName}:AppSecret"];
            if (appKey == null || appSecret == null)
                throw new EhrException(System.Net.HttpStatusCode.BadRequest, "App不存在!");
            DingDingAuthApi authApi = new DingDingAuthApi(_configruation, _logger);
            var ret = await authApi.GetToken(appKey, appSecret);
            return ret.token;
        }

        public OapiV2UserGetuserinfoResponse GetUserInfo(string code, string accessToken)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/v2/user/getuserinfo");
            OapiV2UserGetuserinfoRequest request = new OapiV2UserGetuserinfoRequest();
            request.Code = code;
            OapiV2UserGetuserinfoResponse rsp = client.Execute(request, accessToken);
            return rsp;
        }


    }
}