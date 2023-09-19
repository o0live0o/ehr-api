using System.Net;
using System.Threading.Tasks;
using Ehr.Contracts.Recruit;
using Ehr.Contracts.Sync;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ehr.Web.Controllers
{
    [ApiVersion("2.0")]
    [Authorize(Policy = "AdminPolicy")]
    public class JobController : EhrController
    {
        private readonly IRecruitSyncService _recruitSyncService;
        private readonly ISyncBaseInfoService _syncBaseInfoService;

        public JobController(IRecruitSyncService recruitSyncService,ISyncBaseInfoService syncBaseInfoService)
        {
            this._recruitSyncService = recruitSyncService;
            this._syncBaseInfoService = syncBaseInfoService;
        }

        [HttpGet]
        [Route(nameof(StartRecruitSync))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult StartRecruitSync(string cron)
        {
            _recruitSyncService.StartJob(cron);
            return Ok();
        }

        [HttpGet]
        [Route("test")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        #if DEBUG
        [AllowAnonymous]
        #endif
        public async Task<IActionResult> Test()
        {
            await _recruitSyncService.AutoSyncOfferAndResumeAsync();
            return Ok();
        }
    }
}