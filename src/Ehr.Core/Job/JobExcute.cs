using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Ehr.Core.Job
{
    public class JobExcute
    {
        private readonly IServiceProvider _service;
        private readonly ILogger _logger;

        public JobExcute(IServiceProvider serviceProvider)
        {
            this._service = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            this._logger = _service.GetService(typeof(ILogger<JobExcute>)) as ILogger;
        }

        public async Task ExcuteJobAsync(JobContext context)
        {
            try
            {
                var type = _service.GetService(context.ClassType);
                var method = context.ClassType.GetMethod(context.MethodName);
                await ((Task)method.Invoke(type, context.Args));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void ExcuteJob(JobContext context)
        {
            try
            {
                var type = _service.GetService(context.ClassType);
                var method = context.ClassType.GetMethod(context.MethodName);
                method.Invoke(type, context.Args);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}