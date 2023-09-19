using System.Net;
using System.Threading.Tasks;
using Ehr.Contracts.Base;
using Ehr.Contracts.Base.Dtos;
using Ehr.Core.Base;
using Ehr.Core.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ehr.Web.Controllers
{
    public class SalaryController : EhrController
    {
        private readonly ISalaryService _salaryService;
        private readonly IEhrUserInfo _ehrUserInfo;

        public SalaryController(ISalaryService salaryService, IEhrUserInfo ehrUserInfo)
        {
            this._salaryService = salaryService;
            _ehrUserInfo = ehrUserInfo;
        }

        [Authorize(Policy = "SalaryPolicy")]
        [HttpGet]
        [ProducesResponseType(typeof(EhrResponse<SalaryItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetSalaryAsync([FromQuery] string date)
        {
            var data = await _salaryService.GetSalaryAsync(_ehrUserInfo.UserId, date);
            EhrResponse<SalaryItemDto> response = new EhrResponse<SalaryItemDto>();
            response.Message = "请求成功!";
            response.SetData(data);
            return Ok(response);
        }
    }
}