using System.Net;
using System.Threading.Tasks;
using Ehr.Contracts.Base;
using Ehr.Contracts.Base.Dtos;
using Ehr.Core.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ehr.Web.Controllers
{
    public class HumanController : EhrController
    {
        private readonly IHumansService _humanService;

        public HumanController(IHumansService humanService)
        {
            this._humanService = humanService;
        }

        [Authorize(Policy = "HumanPolicy")]
        [HttpGet]
        [Route("state")]
        [ProducesResponseType(typeof(EhrResponse<HumanStatusResultDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetHumanStateAsync([FromQuery] HumanStatusQueryDto queryDto)
        {
            var data = await _humanService.GetHumanStatusAsync(queryDto);
            EhrResponse<HumanStatusResultDto> response = new EhrResponse<HumanStatusResultDto>();
            response.Message = "请求成功!";
            response.SetData(data);
            return Ok(response);
        }
    }
}