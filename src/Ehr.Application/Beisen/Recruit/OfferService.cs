using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ehr.Application.Beisen.Api;
using Ehr.Application.Beisen.Recruit.Dtos;
using Ehr.Contracts.Recruit;
using Ehr.Contracts.Recruit.Dtos;
using Ehr.Core.Data.Entities;
using Ehr.Core.IRepository;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using Ehr.Core.ExtendMethods;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Collections.Concurrent;
using Newtonsoft.Json.Linq;
using Ehr.Core.Base;

namespace Ehr.Application.Beisen.Recruit
{
    public class OfferService : IOfferService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<OfferService> _logger;
        private readonly IBaseRepository<BASE_SYSTEM_USERS> _userRepo;

        public OfferService(IConfiguration configuration,
                            IMapper mapper,
                            ILogger<OfferService> logger,
                            IBaseRepository<BASE_SYSTEM_USERS> userRepo)
        {
            this._configuration = configuration;
            this._mapper = mapper;
            this._logger = logger;
            this._userRepo = userRepo;
        }

        /// <summary>
        /// 根据ID获取申请信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<ConcurrentDictionary<int, int>> GetNewApplyInfosAsync(string[] ids)
        {
            ConcurrentDictionary<int, int> dic = new ConcurrentDictionary<int, int>();
            OfferApi api = new OfferApi(_configuration, _logger);
            var idsTempArr = ids.SplitArr(1);
            foreach (var item in idsTempArr)
            {
                var resp = await api.GetNewApplyInfosAsync(item);
                if (resp.succ)
                {
                    var applyDto = JsonConvert.DeserializeObject<ApplyDto>(resp.data);
                    foreach (var data in applyDto.Data)
                    {
                        if (data.PersonId <= 0) continue;
                        var job = data.ApplyInfos.Where(p => p.StatusInfo.Code.Equals("U11")).FirstOrDefault();
                        if (job != null)
                        {
                            dic.TryAdd(data.PersonId, job.JobId);
                        }
                    }
                }
            }
            return dic;
        }

        /// <summary>
        /// 获取offer信息
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RecruitOfferDto>> GetOBOfferApplyByPersonAsync(ConcurrentDictionary<int, int> dic)
        {
            List<RecruitOfferDto> recruitOfferDtos = new List<RecruitOfferDto>();
            foreach (var personId in dic.Keys)
            {
                if (!dic.TryGetValue(personId, out int jobId)) continue;

                OfferApi api = new OfferApi(_configuration, _logger);
                var resp = await api.GetOBOfferApplyByPersonAsync(personId, jobId);

                if (!resp.succ)
                {
                    await UpdateOfferStateAsync(personId.ToString(), jobId.ToString(), "S12", "U015");
                    continue;
                }

                var dto = await ExplainOffer(resp.data);

                if (dto == null)
                {
                    await UpdateOfferStateAsync(personId.ToString(), jobId.ToString(), "S12", "U015");
                    continue;
                }

                recruitOfferDtos.Add(dto);
            }
            return recruitOfferDtos;
        }

        /// <summary>
        /// 更新简历状态
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="jobId"></param>
        /// <param name="phaseId"></param>
        /// <param name="statusId"></param>
        /// <returns></returns>
        public async Task UpdateOfferStateAsync(string personId, string jobId, string phaseId, string statusId)
        {
             await Task.CompletedTask;
            // OfferApi offerApi = new OfferApi(_configuration, _logger);
            // await offerApi.ConToJobOrStorsDBAsync(personId, jobId, phaseId, statusId);
        }

        private async Task<RecruitOfferDto> ExplainOffer(string json)
        {
            var offers = JsonConvert.DeserializeObject<List<OfferDto>>(json);
            if (offers?.Count > 0)
            {
                var offer = offers.FirstOrDefault(p =>
                {
                    var tmp = p.ExtendInfos.FirstOrDefault(q => "OfferState".Equals(q.Name) && ("5".Equals(q.Value) || "2".Equals(q.Value)));
                    if (tmp == null) return false;
                    return true;
                });

                if (offer == null) return null;

                RecruitOfferDto recruitOfferDto = new RecruitOfferDto();
                FieldTools.FillEhrField(recruitOfferDto, offer.ExtendInfos);

                //获取组织code和name
                var orgNode = offer.ExtendInfos.FirstOrDefault(p => p.Name.Equals("Org"));
                if (orgNode != null)
                {
                    recruitOfferDto.ORGCODE = orgNode.OtherCode;
                    recruitOfferDto.ORGNAME = orgNode.Text;
                }

                //获取岗位code和name
                var jobNode = offer.ExtendInfos.FirstOrDefault(p => p.Name.Equals("Post"));
                if (jobNode != null && jobNode.Text.Contains("|"))
                {
                    var arr = jobNode.Text.Split('|');
                    recruitOfferDto.JOBCODE = arr[1];
                    recruitOfferDto.JOBNAME = arr[0];
                }

                //获取offer审批人
                var node = offer.ExtendInfos.FirstOrDefault(p => p.Name.Equals("CreatedBy"));
                if (node != null)
                {
                    var email = node.Text.Match(@"\((.*)\)", 1);
                    //根据邮箱从北森系统获取offer审批人的信息
                    var staff = await GetStaffByEmail(email);
                    if (staff != null)
                    {
                        var human = await GteBaseHumanByCode(staff.staffCode);
                        if (human != null)
                        {
                            recruitOfferDto.CREATEDID = human.USERID;
                            recruitOfferDto.CREATEDNAME = human.USERNAME;
                            recruitOfferDto.UPDATEDID = human.USERID;
                            recruitOfferDto.UPDATEDNAME = human.USERNAME;
                        }
                    }
                }
                return recruitOfferDto;
            }
            return null;
        }

        /// <summary>
        /// 根据邮箱获取员工信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private async Task<StaffDto> GetStaffByEmail(string email)
        {
            StaffDto staff = null;
            try
            {
                ItalentApi api = new ItalentApi(_configuration);
                var s = await api.GetStaffByEmail(email);
                JObject obj = JsonConvert.DeserializeObject<JObject>(s);
                if (obj.ContainsKey("items"))
                {
                    staff = JsonConvert.DeserializeObject<StaffDto>(obj["items"][0]["staffDto"]?.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, EhrTips.OFFER_EXCEPTION);
            }
            return staff;
        }

        private async Task<BASE_SYSTEM_USERS> GteBaseHumanByCode(string hrCode)
        {
            return await _userRepo.FirstAsync(p => p.USERCODE.Equals(hrCode));
        }
    }
}