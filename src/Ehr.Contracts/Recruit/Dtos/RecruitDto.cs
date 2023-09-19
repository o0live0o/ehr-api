using System.Collections.Generic;

namespace Ehr.Contracts.Recruit.Dtos
{
    public class RecruitDto
    {
        public RecruitHumanDto RecruitHuman { get; set; }
        public List<RecruitHumanEducationDto> RecruitHumanEducations { get; set; }
        public List<RecruitHumanJobsDto> RecruitHumanJobs { get; set; }
        public List<RecruitHumanRewardDto> recruitHumanRewards { get; set; }
        public List<RecruitHumanRelation> RecruitHumanRelations { get; set; }
        public List<RecruiitHumanTrainDto> RecruiitHumanTrains { get; set; }

    }
}