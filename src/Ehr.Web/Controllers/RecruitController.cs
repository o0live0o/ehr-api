using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Ehr.Contracts.Recruit;
using Ehr.Core.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ehr.Web.Controllers
{

    public class RecruitController : EhrController
    {
        private readonly IRecruitService _recruitService;

        public RecruitController(IRecruitService recruitService)
        {
            this._recruitService = recruitService;
        }

        [Authorize(Policy = "BlackPolicy")]
        [HttpGet]
        [Route(nameof(ValidateBlackList))]
        [ProducesResponseType(typeof(EhrResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ValidateBlackList([FromQuery] string IDNumber = "", [FromQuery] int IDType = 0, [FromQuery] string phone = "")
        {
            var exists = await _recruitService.ValidateBlackListAsync(IDNumber, IDType, phone);
            EhrResponse response = new EhrResponse();
            response.Code = exists.exists ? 400 : 200;
            var tag = string.IsNullOrEmpty(IDNumber) ? phone : IDNumber;
            response.Message = exists.reason;
            return Ok(response);
        }
    }
}