using System.Threading.Tasks;
using Ehr.Contracts.Base.Dtos;

namespace Ehr.Contracts.Base
{
    public interface IHumansService
    {
        Task<HumanStatusResultDto> GetHumanStatusAsync(HumanStatusQueryDto humanStatusQueryDto);
    }
}