using Ehr.Core.Job;

namespace Ehr.Contracts.Job
{
    public interface IJobService
    {
        /// <summary>
        /// 添加定时任务
        /// </summary>
        /// <param name="jobContext"></param>
        /// <param name="queue">任务队列</param>
        void AddRecurringJob(JobContext jobContext, string queue = null);

        /// <summary>
        /// 添加异步定时任务
        /// </summary>
        /// <param name="jobContext"></param>
        /// <param name="queue">任务队列</param>
        void AddRecurringAsyncJob(JobContext jobContext, string queue = null);

    }
}