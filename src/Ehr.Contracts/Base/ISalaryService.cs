using System.Collections.Generic;
using System.Threading.Tasks;
using Ehr.Contracts.Base.Dtos;

namespace Ehr.Contracts.Base
{
    public interface ISalaryService
    {
        Task<IEnumerable<SalaryItemDto>> GetSalaryAsync(string hrCode, string date);
    }
}