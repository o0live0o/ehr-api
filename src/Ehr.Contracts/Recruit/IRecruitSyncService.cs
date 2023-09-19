using System.Threading.Tasks;

namespace Ehr.Contracts.Recruit
{
    public interface IRecruitSyncService
    {
        /// <summary>
        /// 自动拉取简历和offer
        /// </summary>
        /// <returns></returns>
        Task AutoSyncOfferAndResumeAsync();

        /// <summary>
        /// 启动任务
        /// </summary>
        /// <param name="cron">时间规则</param>
        void StartJob(string cron);

    }
}