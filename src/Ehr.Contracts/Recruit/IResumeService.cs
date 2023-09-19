using System.Collections.Generic;
using System.Threading.Tasks;
using Ehr.Contracts.Recruit.Dtos;

namespace Ehr.Contracts.Recruit
{
    public interface IResumeService
    {

        /// <summary>
        /// 根据应聘者id获取应聘者基本信息
        /// </summary>
        /// <param name="personids">应聘者id数组,最大100个</param>
        /// <param name="hasLong">返回的ElinkUrl是否为长链接 1-长 2-短</param>
        /// <returns></returns>
        Task<IEnumerable<RecruitDto>> GetApplicantProfileByIdAsync(string[] personids, string hasLong = "1");

        /// <summary>
        /// 获取应聘者id
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="statusId">状态id</param>
        /// <param name="phaseId">阶段id</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetResumeIdsAsync(string startTime, string endTime, string statusId, string phaseId);


    }
}