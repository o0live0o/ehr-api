using System.Threading.Tasks;

namespace Ehr.Contracts.Recruit
{
    public interface IRecruitService
    {
        /// <summary>
        /// 验证黑名单
        /// </summary>
        /// <param name="exists">是否在黑名单</param>
        /// <param name="idNum">证件号码</param>
        /// <param name="idType">证件类型</param>
        /// <param name="phone">电话号码</param>
        /// <returns></returns>
        Task<(bool exists, string reason)> ValidateBlackListAsync(string idNum = "", int idType = 0, string phone = "");
    }
}