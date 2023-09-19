using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Ehr.Contracts.Base;
using Ehr.Contracts.Base.Dtos;
using Ehr.Core.Exceptions;
using EhrDlls;
using Newtonsoft.Json;

namespace Ehr.Application.Base
{
    public class SalaryService : ISalaryService
    {
        public async Task<IEnumerable<SalaryItemDto>> GetSalaryAsync(string hrCode, string date)
        {
            if (string.IsNullOrEmpty(hrCode))
                throw new EhrException(HttpStatusCode.BadRequest, "Hr Code 不能为空!");

            if (string.IsNullOrEmpty(date))
                throw new EhrException(HttpStatusCode.BadRequest, "日期不能为空!");

            var ret = SalaryDll.salary.getArticleWages(hrCode, date);

            if (ret == null) return null;

            var list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(ret);
            if (list.Count < 1)
                return null;

            List<SalaryItemDto> salaries = new List<SalaryItemDto>();
            foreach (var item in list[0].Keys)
            {
                salaries.Add(new SalaryItemDto { ItemName = item, ItemValue = list[0][item] });
            }

            await Task.CompletedTask;
            return salaries;
        }
    }
}