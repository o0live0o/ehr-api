using System.Threading.Tasks;
using Ehr.Contracts.Recruit;
using Ehr.Core.Base;
using Ehr.Core.Data.Entities;
using Ehr.Core.Exceptions;
using Ehr.Core.IRepository;

namespace Ehr.Application.Beisen.Recruit
{
    public class RecruitService : IRecruitService
    {
        private readonly IBaseRepository<BASE_PARAMETER_HUMANS> _huamnRepo;
        private readonly IBaseRepository<FLOW_JOB_LEAVE_HEAD> _leaveRepo;

        public RecruitService(IBaseRepository<BASE_PARAMETER_HUMANS> huamnRepo, IBaseRepository<FLOW_JOB_LEAVE_HEAD> leaveRepo)
        {
            this._huamnRepo = huamnRepo;
            _leaveRepo = leaveRepo;
        }

        public async Task<(bool exists, string reason)> ValidateBlackListAsync(string idNum = "", int idType = 0, string phone = "")
        {
            bool exists = false;
            var tag = string.IsNullOrEmpty(idNum) ? phone : idNum;
            string reason = string.Format(EhrTips.NOT_IN_BLACKLIST, tag);
            if (string.IsNullOrEmpty(idNum?.Trim()) && string.IsNullOrEmpty(phone?.Trim()))
                throw new EhrException(400, EhrTips.REQ_PARAM_ERROR);

            BASE_PARAMETER_HUMANS human = null;

            if (!string.IsNullOrEmpty(idNum?.Trim()))
                human = await _huamnRepo.FirstAsync(p => p.IDTYPE.Equals(idType) && p.IDCARDNO.Equals(idNum));
            else
                human = await _huamnRepo.FirstAsync(p => p.HRMOBIL.Equals(phone));

            exists = human != null;

            if (exists)
            {
                var leave = await _leaveRepo.FirstAsync(p => p.HRCODE.Equals(human.HRCODE));
                if (leave != null)
                    reason = string.Format(EhrTips.LEAVE_REASON, tag, leave.LEAVETYPENAME);
                else
                    reason = string.Format(EhrTips.IN_BLACKLIST, tag);
            }

            return (exists, reason);
        }
    }
}