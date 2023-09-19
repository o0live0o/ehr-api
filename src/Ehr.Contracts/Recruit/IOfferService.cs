using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ehr.Contracts.Recruit.Dtos;

namespace Ehr.Contracts.Recruit
{
    public interface IOfferService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<ConcurrentDictionary<int, int>> GetNewApplyInfosAsync(string[] ids);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        Task<IEnumerable<RecruitOfferDto>> GetOBOfferApplyByPersonAsync(ConcurrentDictionary<int, int> dic);
        Task UpdateOfferStateAsync(string personId, string jobId, string phaseId, string statusId);
    }
}