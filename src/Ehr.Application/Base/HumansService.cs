using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Ehr.Contracts.Base;
using Ehr.Contracts.Base.Dtos;
using Ehr.Core.Base;
using Ehr.Core.Data.Entities;
using Ehr.Core.Exceptions;
using Ehr.Core.IRepository;

namespace Ehr.Application.Base
{
    public class HumansService : IHumansService
    {
        private readonly IBaseRepository<BASE_PARAMETER_HUMANS> _huamnRepo;

        public HumansService(IBaseRepository<BASE_PARAMETER_HUMANS> huamnRepo)
        {
            this._huamnRepo = huamnRepo;
        }

        public Dictionary<int, string> dic = new Dictionary<int, string>{
           {0,"试用"},
           {1,"在职"},
           {2,"停职"},
           {3,"离职"},
           {4,"删除"},
        };
        public async Task<HumanStatusResultDto> GetHumanStatusAsync(HumanStatusQueryDto humanStatusQueryDto)
        {
            if (string.IsNullOrEmpty(humanStatusQueryDto.Val) &&
               string.IsNullOrEmpty(humanStatusQueryDto.LoginType))
                throw new EhrException(HttpStatusCode.BadRequest, EhrTips.REQ_PARAM_ERROR);

            BASE_PARAMETER_HUMANS human = null;

            if ("1".Equals(humanStatusQueryDto.LoginType))
                human = await _huamnRepo.FirstAsync(p => p.HRCODE.Equals(humanStatusQueryDto.Val));
            else if ("2".Equals(humanStatusQueryDto.LoginType))
                human = await _huamnRepo.FirstAsync(p => p.HRMOBIL.Equals(humanStatusQueryDto.Val));
            else if ("3".Equals(humanStatusQueryDto.LoginType))
                human = await _huamnRepo.FirstAsync(p => p.EMAILADDR.Equals(humanStatusQueryDto.Val));
            else
                throw new EhrException(HttpStatusCode.BadRequest, EhrTips.ILLEGAL_LOGIN_TYPE);

            if (human == null)
                throw new EhrException(HttpStatusCode.NotFound, EhrTips.HUMAN_NOT_EXISTS);

            HumanStatusResultDto resultDto = new HumanStatusResultDto();
            resultDto.AllowLogin = human.HRSTATUS < 2;
            resultDto.Status = human.HRSTATUS;
            resultDto.Name = human.HRNAME;
            if (dic.TryGetValue(human.HRSTATUS, out string val))
            {
                resultDto.Description = val;
            }
            return resultDto;

        }
    }
}