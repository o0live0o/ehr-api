using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Ehr.Contracts.Job;
using Ehr.Contracts.Recruit;
using Ehr.Contracts.Recruit.Dtos;
using Ehr.Core.Base;
using Ehr.Core.Data;
using Ehr.Core.Data.Entities;
using Ehr.Core.ExtendMethods;
using Ehr.Core.IRepository;
using Ehr.Core.Job;
using Ehr.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ehr.Application.Beisen.Recruit
{
    public class RecruitSyncService : IRecruitSyncService
    {
        private readonly IConfiguration _configuration;
        private readonly IResumeService _resumeService;
        private readonly IBaseRepository<BASE_THIRD_ENUMS> _enumRepo;
        private readonly IOfferService _offerSrvice;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<FLOW_RECRUIT_HUMANS> _humanRepo;
        private readonly IBaseRepository<FLOW_RECRUIT_OFFER> _offerRepo;
        private readonly IBaseRepository<FLOW_RECRUIT_HUMANS_EDUCATION> _educationRepo;
        private readonly ILogger<RecruitSyncService> _logger;
        private readonly IJobService _jobService;
        private readonly EhrDbContext _dbContext;

        public RecruitSyncService(IConfiguration configuration,
                                  IResumeService resumeService,
                                  IBaseRepository<BASE_THIRD_ENUMS> enumRepo,
                                  IOfferService offerSrvice,
                                  IMapper mapper,
                                  IBaseRepository<FLOW_RECRUIT_HUMANS> humanRepo,
                                  IBaseRepository<FLOW_RECRUIT_OFFER> offerRepo,
                                  IBaseRepository<FLOW_RECRUIT_HUMANS_EDUCATION> educationRepo,
                                  ILogger<RecruitSyncService> logger,
                                  IJobService jobService,
                                  EhrDbContext dbContext)

        {
            this._configuration = configuration;
            this._resumeService = resumeService;
            this._enumRepo = enumRepo;
            this._offerSrvice = offerSrvice;
            this._mapper = mapper;
            this._humanRepo = humanRepo;
            this._offerRepo = offerRepo;
            this._educationRepo = educationRepo;
            this._logger = logger;
            this._jobService = jobService;
            this._dbContext = dbContext;
        }

        public void StartJob(string cron)
        {
            JobContext jobContext = new JobContext();
            jobContext.MethodName = nameof(AutoSyncOfferAndResumeAsync);
            jobContext.JobName = "北森简历同步任务";
            jobContext.ClassType = typeof(IRecruitSyncService);
            jobContext.Cron = cron;
            _jobService.AddRecurringAsyncJob(jobContext);
        }

        /// <summary>
        /// 自动同步逻辑
        /// </summary>
        /// <returns></returns>
        public async Task AutoSyncOfferAndResumeAsync()
        {
            try
            {
                var startTime = DateTime.Now.AddDays(-10).ToString("yyyyMMddHHmmss");
                var endTime = DateTime.Now.AddDays(1).ToString("yyyyMMddHHmmss");

                //获取枚举值
                var enums = await _enumRepo.QueryAsync();
                FieldTools.SetEnums(enums.ToArray());

                //获取startTime和endTime之间入职人员id列表
                var ids = (await _resumeService.GetResumeIdsAsync(startTime, endTime, "U11", "S12"))?.ToArray();
                if (ids == null || ids.Length == 0)
                {
                    _logger.LogError("没有新的简历Id!");
                    return;
                }

                // foreach (var id in ids)
                // {
                //     Applicant applicant = new Applicant(id);
                //     applicant.SyncResume();
                //     applicant.SyncOffer();
                // }

                //获取入职人员简历
                var recruitDtos = (await _resumeService.GetApplicantProfileByIdAsync(ids.ToArray()))?.ToArray();
                if (recruitDtos == null || recruitDtos.Length == 0)
                {
                    _logger.LogError("没有新的简历!");
                    return;
                }

                //获取申请人申请的岗位
                var personJobDic = await _offerSrvice.GetNewApplyInfosAsync(ids.ToArray());

                //把jobid储存到人员信息
                foreach (var recruit in recruitDtos)
                {
                    if (personJobDic.TryGetValue(recruit.RecruitHuman.BS_PersionId.ToInt(), out int jobId))
                        recruit.RecruitHuman.BS_JobId = jobId.ToString();
                }

                //保存人员信息
                await SaveResumeAsync(recruitDtos);
                _logger.LogInformation(EhrTips.SYNC_RESUME_SUCC);

                //获取入职人员offer
                var recruitOfferDtos = (await _offerSrvice.GetOBOfferApplyByPersonAsync(personJobDic))?.ToArray();

                if (recruitOfferDtos == null || recruitOfferDtos.Length == 0)
                {
                    _logger.LogError(string.Format(EhrTips.EMPTY_OFFER, string.Join(",", ids)));
                    return;
                }

                //获取简历人员id
                var offerPersonIds = recruitOfferDtos.Select(p => p.BS_PERSIONID).ToArray();

                //筛选没有offer的简历
                var ignoreHuman = recruitDtos.Where(p => !offerPersonIds.Contains(p.RecruitHuman.BS_PersionId))?.ToArray();
                if (ignoreHuman != null && ignoreHuman.Length > 0)
                    _logger.LogError(EhrTips.EMPTY_OFFER, string.Format(string.Join(',', ignoreHuman.Select(p => p.RecruitHuman.BS_PersionId).ToArray())));

                //保存offer
                await SaveOfferAsync(recruitOfferDtos);
                _logger.LogInformation(EhrTips.SYNC_OFFER_SUCC);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Format(EhrTips.SYNC_ERROR, ex.Message));
            }
        }

        #region  保存人员基本信息
        private async Task SaveResumeAsync(RecruitDto[] recruitDtos)
        {
            foreach (var recruit in recruitDtos)
            {

                //保存人员信息
                var humorRowId = await SaveHumanAsync(recruit.RecruitHuman);
                //保存教育经历
                recruit.RecruitHumanEducations.ForEach(p => { p.HUMROWID = humorRowId; p.HRNAME = recruit.RecruitHuman.HRNAME; p.UPDATEDDATE = DateTime.Now; });
                await SaveOtherAsync<RecruitHumanEducationDto, FLOW_RECRUIT_HUMANS_EDUCATION>(recruit.RecruitHumanEducations,
                    p => q => q.BEGINDATE == p.BEGINDATE && q.ENDDATE == p.ENDDATE && q.HUMROWID == p.HUMROWID
                );

                // 保存工作经历
                recruit.RecruitHumanJobs.ForEach(p => { p.HUMROWID = humorRowId; p.HRNAME = recruit.RecruitHuman.HRNAME; p.UPDATEDDATE = DateTime.Now; });
                await SaveOtherAsync<RecruitHumanJobsDto, FLOW_RECRUIT_HUMANS_JOBS>(recruit.RecruitHumanJobs,
                    p => q => q.BEGINDATE == p.BEGINDATE && q.ENDDATE == p.ENDDATE && q.HUMROWID == p.HUMROWID
                );

                // 保存获奖经历
                recruit.recruitHumanRewards.ForEach(p => { p.HUMROWID = humorRowId; p.HRNAME = recruit.RecruitHuman.HRNAME; p.UPDATEDDATE = DateTime.Now; });
                await SaveOtherAsync<RecruitHumanRewardDto, FLOW_RECRUIT_HUMANS_REWARD>(recruit.recruitHumanRewards,
                    p => q => q.BEGINDATE == p.BEGINDATE && q.ENDDATE == p.ENDDATE && q.HUMROWID == p.HUMROWID && q.REWARD == p.REWARD
                );

                // 保存亲属关系
                recruit.RecruitHumanRelations.ForEach(p => { p.HUMROWID = humorRowId; p.HRNAME = recruit.RecruitHuman.HRNAME; p.UPDATEDDATE = DateTime.Now; });
                await SaveOtherAsync<RecruitHumanRelation, FLOW_RECRUIT_HUMANS_RELATION>(recruit.RecruitHumanRelations.Where(p => !string.IsNullOrEmpty(p.FULLNAME)).ToList(),
                    p => q => q.HUMROWID == p.HUMROWID && q.FULLNAME == p.FULLNAME
                );

                // 保存培训经历
                recruit.RecruiitHumanTrains.ForEach(p => { p.HUMROWID = humorRowId; p.HRNAME = recruit.RecruitHuman.HRNAME; p.UPDATEDDATE = DateTime.Now; });
                await SaveOtherAsync<RecruiitHumanTrainDto, FLOW_RECRUIT_HUMANS_TRAIN>(recruit.RecruiitHumanTrains,
                           p => q => q.BEGINDATE == p.BEGINDATE && q.ENDDATE == p.ENDDATE && q.HUMROWID == p.HUMROWID
                       );
            }
        }

        /// <summary>
        /// 保存简历信息
        /// </summary>
        /// <param name="humanDto"></param>
        /// <returns>自增id</returns>
        private async Task<int> SaveHumanAsync(RecruitHumanDto humanDto)
        {
            try
            {
                if (humanDto == null) return 0;
                FLOW_RECRUIT_HUMANS human = null;
                
                if(string.IsNullOrEmpty(humanDto?.IDCARDNO)) 
                    human = await _humanRepo.FirstAsync(p => p.BS_PersionId == humanDto.BS_PersionId);
                else
                    human = await _humanRepo.FirstAsync(p => p.IDCARDNO == humanDto.IDCARDNO);

                if (human == null)
                {
                    human = new FLOW_RECRUIT_HUMANS();
                    _humanRepo.Add(human);
                }
                _mapper.Map(humanDto, human);
                human.UPDATEDDATE = DateTime.Now;
                await _humanRepo.SaveChangeAsync();
                human = await _humanRepo.FirstAsync(p => p.BS_PersionId == humanDto.BS_PersionId);
                if (human == null) return 0;
                return human.ROWID;
            }
            catch (Exception ex)
            {
                _humanRepo.RejectChanges();
                _logger.LogError(ex, EhrTips.SAVE_RESUME_ERROR);
                return 0;
            }
        }
        #endregion

        #region 保存offer
        private async Task SaveOfferAsync(RecruitOfferDto[] offerDtos)
        {
            foreach (var offerDto in offerDtos)
            {
                await SaveOfferAsync(offerDto);
            }
        }

        /// <summary>
        /// 保存offer信息
        /// </summary>
        /// <param name="offerDto"></param>
        /// <returns></returns>
        private async Task SaveOfferAsync(RecruitOfferDto offerDto)
        {
            try
            {
                if (offerDto == null) return;
                FLOW_RECRUIT_OFFER offer = null;
                offer = await _offerRepo.FirstAsync(p => p.VIEWROWID == offerDto.BS_PERSIONID.ToInt());
                if (offer == null)
                {
                    offer = new FLOW_RECRUIT_OFFER();
                    offer.VIEWROWID = offerDto.BS_PERSIONID.ToInt();
                    _offerRepo.Add(offer);
                }
                _mapper.Map(offerDto, offer);
                offer.UPDATEDDATE = DateTime.Now;
                var ret = await _offerRepo.SaveChangeAsync();
                //保存成功后更新offer状态
                if (ret > 0)
                    await _offerSrvice.UpdateOfferStateAsync(offerDto.BS_PERSIONID, offerDto.BS_JOBID, "S12", "U014");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"保存offer失败{offerDto.BS_PERSIONID}");
                _offerRepo.RejectChanges();
                await _offerSrvice.UpdateOfferStateAsync(offerDto.BS_PERSIONID, offerDto.BS_JOBID, "S12", "U015");
            }
        }
        #endregion

        #region 保存其他信息
        private async Task SaveOtherAsync<TOtherDto, TOther>(List<TOtherDto> others, Expression<Func<TOtherDto, Expression<Func<TOther, bool>>>> @where) where TOther : BaseEntity, new()
        {
            foreach (var other in others)
            {
                await SaveOtherAsync<TOtherDto, TOther>(other, @where);
            }
        }

        private async Task SaveOtherAsync<TOtherDto, TOther>(TOtherDto otherDto, Expression<Func<TOtherDto, Expression<Func<TOther, bool>>>> @where) where TOther : BaseEntity, new()
        {
            try
            {
                if (otherDto == null) return;
                var exp = @where.Compile().Invoke(otherDto);
                TOther other = null;
                other = _dbContext.Set<TOther>().Where(exp).FirstOrDefault();
                bool isNew = false;
                if (other == null)
                {
                    other = new TOther();
                    isNew = true;
                }
                _mapper.Map(otherDto, other);
                if (isNew)
                    _dbContext.Set<TOther>().Add(other);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                RejectChanges();
                _logger.LogError(ex, $"保存其他信息失败[{typeof(TOther).Name}]");
            }
        }
        #endregion

        /// <summary>
        /// 回滚更改
        /// </summary>
        private void RejectChanges()
        {
            try
            {
                foreach (var entry in _dbContext.ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, EhrTips.REJECT_ERROR);
            }
        }
    }
}