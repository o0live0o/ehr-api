using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Ehr.Contracts.Base;
using Microsoft.AspNetCore.Mvc;

namespace Ehr.Web.Controllers
{
    [ApiVersion("1.0")]
    public class AuthController : EhrController
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            this._loginService = loginService;
        }

        [HttpPost]
        [Route("~/api/authentication")]
        public async Task<ActionResult<TokenDto>> Authentication([Required][FromForm] string AppId, [Required][FromForm] string AppKey)
        {
            var token = await _loginService.LoginAsync(AppId, AppKey);
            return Ok(token);
        }

        [HttpPost]
        [Route("~/api/ding-talk/authentication")]
        public async Task<ActionResult<TokenDto>> DingTalkAuthentication([Required][FromForm] string appName, [Required][FromForm] string code)
        {
            var token = await _loginService.LoginDingTalkAsync(appName, code);
            return Ok(token);
        }
    }
}