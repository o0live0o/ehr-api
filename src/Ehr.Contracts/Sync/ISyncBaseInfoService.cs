using System.Threading.Tasks;

namespace Ehr.Contracts.Sync
{
    public interface ISyncBaseInfoService
    {
        /// <summary>
        /// EHR信息同步任务
        /// </summary>
        /// <returns></returns>
         Task SyncEhrJobAsync();
    }
}