using System;
using System.Linq;
using System.Runtime.InteropServices;
using Ehr.Contracts.Job;
using Ehr.Core.Job;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace Ehr.Application.Job
{
    public class HangfireService : IJobService
    {
        private readonly IConfiguration _configuration;

        private static string _timeZoneId = "Asia/Shanghai";

        private static string _defaultQueue = "default";

        public HangfireService(IConfiguration configuration)
        {
            this._configuration = configuration;
            //根据系统环境设置时区
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                _timeZoneId = "Asia/Shanghai";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _timeZoneId = "China Standard Time";
            }

            var queues = _configuration.GetSection("Hangfire:Queues").GetChildren().Select(p => p.Value).ToList();
            if (queues.Count > 0)
                _defaultQueue = queues[0].ToLower();
        }
        
        public void AddRecurringJob(JobContext jobContext, string queue = null)
        {
            RecurringJob.AddOrUpdate<JobExcute>(jobContext.JobName, job => job.ExcuteJob(jobContext), jobContext.Cron, TimeZoneInfo.FindSystemTimeZoneById(_timeZoneId), queue ?? _defaultQueue);
        }

        public void AddRecurringAsyncJob(JobContext jobContext, string queue = null)
        {
            RecurringJob.AddOrUpdate<JobExcute>(jobContext.JobName, job => job.ExcuteJobAsync(jobContext), jobContext.Cron, TimeZoneInfo.FindSystemTimeZoneById(_timeZoneId), queue ?? _defaultQueue);
        }
    }
}