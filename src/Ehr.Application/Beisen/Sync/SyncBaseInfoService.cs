using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ehr.Application.Beisen.Api;
using Ehr.Application.Beisen.Sync.Dtos;
using Ehr.Contracts.Sync;
using Ehr.Core.Data.Entities;
using Ehr.Core.IRepository;
using Ehr.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ehr.Application.Beisen.Sync
{
    public class SyncBaseInfoService : ISyncBaseInfoService
    {
        private readonly IBaseRepository<BASE_PARAMETER_ORGJOBS> _orgJobsRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SyncBaseInfoService> _logger;
        private readonly IServiceProvider _services;

        public SyncBaseInfoService(IBaseRepository<BASE_PARAMETER_ORGJOBS> orgJobsRepository,
                                   IConfiguration configuration,
                                   ILogger<SyncBaseInfoService> logger,
                                   IServiceProvider services)
        {
            this._orgJobsRepository = orgJobsRepository ?? throw new System.ArgumentNullException(nameof(orgJobsRepository));
            this._configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
            this._logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            this._services = services;
        }
        public async Task SyncEhrJobAsync()
        {
            var tenantId = _configuration["Beisen:TenantId"];
            var email = _configuration["Beisen:E-mail"];
            await Task.Yield();
            Thread thread = new Thread(async () =>
            {
                var repository = EhrServiceProvider.Instance.GetService<IBaseRepository<BASE_PARAMETER_ORGJOBS>>();
                var jobs = await repository.QueryAsync(p => !string.IsNullOrEmpty(p.OB_JOB_ID));
                foreach (var item in jobs)
                {
                    ObPostDto obPost = new ObPostDto
                    {
                        id = item.OB_JOB_ID,
                        tenant_id = tenantId,
                        CreateEmail = email,
                        Name = $"{item.JOBNAME}|{item.JOBCODE}",
                        Org = $"{item.ORGCODE}"
                        
                    };
                    ObPostApi api = new ObPostApi(_configuration, _logger);
                    var resp = await api.UpdateObPost(obPost);
                    if (resp.Code == "200")
                    {
                        item.OB_JOB_ID = resp.Data;
                        _logger.LogInformation($"{obPost.Org} {obPost.Name} 上传成功 {item.OB_JOB_ID}");
                    }
                    else
                    {
                        _logger.LogError(JsonConvert.SerializeObject(resp));
                    }

                }
               // var updateFlag = await repository.SaveChangeAsync();

            });
            thread.IsBackground = true;

            thread.Start();
        }
    }
}
