using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ehr.Application.Base;
using Ehr.Application.Beisen.Api;
using Ehr.Application.Beisen.Recruit.Dtos;
using Ehr.Contracts.Base;
using Ehr.Core.ExtendMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Ehr.Test
{
    public class UnitTest1
    {
        public UnitTest1()
        {

        }

        [Fact]
        public void Test1()
        {
            try
            {
                var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.Production.json", optional: true)
              .AddEnvironmentVariables().Build();

                IServiceCollection services = new ServiceCollection();
                services.AddSingleton<IConfiguration>(config);
                ServiceProvider serviceProvider = services.BuildServiceProvider();
                var configuration = serviceProvider.GetService<IConfiguration>();
                ItalentApi italentApi = new ItalentApi(configuration);
                var email = "北森顾问_张迪(zhangdi3602118@beisenshishi.com)".Match(@"\((.*)\)", 1);
                email = "chelei@yurun.com";
                var ret = italentApi.GetStaffByEmail(email).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Fact]
        public async Task TestSalary()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<ISalaryService, SalaryService>();
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            try
            {
                var salaryService = serviceProvider.GetService<ISalaryService>();
                var salary = await salaryService.GetSalaryAsync("08007728", "2020-12");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Fact]
        public void TestId()
        {
            ConcurrentDictionary<int, int> dic = new ConcurrentDictionary<int, int>();
            var s = File.ReadAllText("applyinfo.txt");
            var applyDto = JsonConvert.DeserializeObject<ApplyDto>(s);
            foreach (var data in applyDto.Data)
            {
                if (data.PersonId <= 0) continue;
                var job = data.ApplyInfos.Where(p => p.StatusInfo.Code.Equals("U11")).FirstOrDefault();
                if (job != null)
                {
                    dic.TryAdd(data.PersonId, job.JobId);
                }
            }
        }
    }
}
