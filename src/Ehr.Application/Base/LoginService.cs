using System.Linq;
using System.Threading.Tasks;
using Ehr.Application.DingDing;
using Ehr.Contracts.Base;
using Ehr.Core.Exceptions;
using Ehr.Core.ExtendMethods;
using Ehr.Core.Utils;
using Microsoft.Extensions.Configuration;

namespace Ehr.Application.Base
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly DingDingAuthService _dingTalkService;

        public LoginService(ITokenService tokenService, IConfiguration configuration, DingDingAuthService dingTalkService)
        {
            this._tokenService = tokenService;
            this._configuration = configuration;
            this._dingTalkService = dingTalkService;
        }

        public async Task<TokenDto> LoginAsync(string id, string key)
        {
            var section = _configuration.GetSection("APPs").GetChildren().Where(p => id.Equals(p.GetValue<string>("Id")) && key.Equals(p.GetValue<string>("Key")))?.ToArray();

            if (section == null || section.Length == 0)
                throw new EhrException(400, "登录id/key不正确");

            var iat = TimeUtil.GetTime();
            var expireTime = TimeUtil.GetTime(_configuration["Auth:ExpireTime"].ToInt() * 60 * 1000);
            var roles = new string[] { section[0].GetValue<string>("Role") };
            var token = await _tokenService.CreateToken(id, roles.ToArray());
            return new TokenDto
            {
                AccessToken = token,
                IssuedAt = iat,
                Expire = expireTime
            };
        }

        public async Task<TokenDto> LoginDingTalkAsync(string appName, string code)
        {
            var userInfo = await _dingTalkService.DingDingLoginAsync(appName, code);
            var iat = TimeUtil.GetTime();
            var expireTime = TimeUtil.GetTime(_configuration["Auth:ExpireTime"].ToInt() * 60 * 1000);
            var roles = new string[] { "Salary" };
            var token = await _tokenService.CreateToken(userInfo.Userid, roles.ToArray());
            return new TokenDto
            {
                AccessToken = token,
                IssuedAt = iat,
                Expire = expireTime
            };
        }
    }
}