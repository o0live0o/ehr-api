using AutoMapper;
using Ehr.Contracts.Recruit.Dtos;
using Ehr.Core.Data.Entities;

namespace Ehr.Application.Profiles
{
    public class RecruitProfile : Profile
    {
        public RecruitProfile()
        {
            CreateMap<RecruitHumanDto, FLOW_RECRUIT_HUMANS>();
            CreateMap<RecruitOfferDto, FLOW_RECRUIT_OFFER>();
            CreateMap<RecruitHumanEducationDto, FLOW_RECRUIT_HUMANS_EDUCATION>();
            CreateMap<RecruitHumanJobsDto, FLOW_RECRUIT_HUMANS_JOBS>();
            CreateMap<RecruitHumanRewardDto, FLOW_RECRUIT_HUMANS_REWARD>();
            CreateMap<RecruiitHumanTrainDto, FLOW_RECRUIT_HUMANS_TRAIN>();
            CreateMap<RecruitHumanRelation, FLOW_RECRUIT_HUMANS_RELATION>();
        }
    }
}