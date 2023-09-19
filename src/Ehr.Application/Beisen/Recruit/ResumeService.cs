using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ehr.Application.Beisen.Api;
using Ehr.Application.Beisen.Recruit.Dtos;
using Ehr.Contracts.Recruit;
using Ehr.Contracts.Recruit.Dtos;
using Ehr.Core.Data.Entities;
using Ehr.Core.ExtendMethods;
using Ehr.Core.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ehr.Application.Beisen.Recruit
{
    public class ResumeService : IResumeService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<BASE_PARAMETER_ENUMVALUE> _enumRepository;
        private readonly IBaseRepository<BASE_THIRD_ENUMS> _thirdEnumsRepository;
        private readonly ILogger<ResumeService> _logger;

        public ResumeService(IConfiguration configuration,
                             IMapper mapper,
                             IBaseRepository<BASE_PARAMETER_ENUMVALUE> enumRepository,
                             IBaseRepository<BASE_THIRD_ENUMS> thirdEnumsRepository,
                             ILogger<ResumeService> logger)
        {
            this._configuration = configuration;
            this._mapper = mapper;
            this._enumRepository = enumRepository;
            this._thirdEnumsRepository = thirdEnumsRepository;
            this._logger = logger;
            FieldTools.SetLogger(logger);
        }

        #region  IResumeService
        public async Task<IEnumerable<string>> GetResumeIdsAsync(string startTime, string endTime, string statusId, string phaseId)
        {
            ApplicantApi api = new ApplicantApi(_configuration, _logger);
            var resp = await api.GetApplicantIdsByDateAndStatus(startTime, endTime, statusId, phaseId);
            return resp.ids;
        }
    
        /// <summary>
        /// 获取简历信息
        /// </summary>
        /// <param name="personids"></param>
        /// <param name="hasLong"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RecruitDto>> GetApplicantProfileByIdAsync(string[] personids, string hasLong = "1")
        {
            List<RecruitDto> recruitDtos = new List<RecruitDto>();

            if (personids == null)
                return recruitDtos;

            var ids = personids.SplitArr(1);

            foreach (var item in ids)
            {
                ApplicantApi api = new ApplicantApi(_configuration, _logger);
                var resp = await api.GetApplicantProfileById(item, hasLong);
                if (resp.succ)
                {
                    recruitDtos.AddRange(ExplainApplicant(resp.data).ToArray());
                }
            }
            return recruitDtos;
        }
        #endregion

        /// <summary>
        /// 解释北森返回的数据
        /// </summary>
        /// <param name="applicants"></param>
        /// <returns></returns>
        private IEnumerable<RecruitDto> ExplainApplicant(string json)
        {
            List<RecruitDto> recruits = new List<RecruitDto>();
            JObject jObj = JsonConvert.DeserializeObject<JObject>(json);
            var applicants = JsonConvert.DeserializeObject<List<ApplicantDto>>(jObj["applicants"].ToString());
            foreach (var item in applicants)
            {
                RecruitDto recruitDto = new RecruitDto();

                var code = item.ApplicantProfile.FirstOrDefault(a => a.PropertyName == "personId")?.Code;
                if (string.IsNullOrEmpty(code) || code == "0") continue;

                //获取人员信息
                var humanDto = FieldTools.FillEhrField<RecruitHumanDto>(item.ApplicantProfile);
                recruitDto.RecruitHuman = humanDto;
                //教育经历
                var educationDtos = FieldTools.FillEhrFieldList<RecruitHumanEducationDto>(item.ResumeForEducationList);
                recruitDto.RecruitHumanEducations = educationDtos;
                //工作经历
                var jobsDtos = FieldTools.FillEhrFieldList<RecruitHumanJobsDto>(item.ResumeForExperienceList);
                recruitDto.RecruitHumanJobs = jobsDtos;
                //获奖经历
                var rewardDtos = FieldTools.FillEhrFieldList<RecruitHumanRewardDto>(item.ResumeForAwardsWonList);
                recruitDto.recruitHumanRewards = rewardDtos;
                //获取培训经历
                var trainDtos = FieldTools.FillEhrFieldList<RecruiitHumanTrainDto>(item.ResumeForTrainList);
                recruitDto.RecruiitHumanTrains = trainDtos;
                //获取亲友关系
                var familyDtos = FieldTools.FillEhrFieldList<RecruitHumanRelation>(item.ResumeForFamilyList);
                recruitDto.RecruitHumanRelations = familyDtos;

                recruits.Add(recruitDto);
            }
            return recruits;
        }
    }
}