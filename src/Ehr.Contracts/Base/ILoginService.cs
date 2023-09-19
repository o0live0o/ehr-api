using System.Threading.Tasks;

namespace Ehr.Contracts.Base
{
    public interface ILoginService
    {
        Task<TokenDto> LoginAsync(string id, string key);
        Task<TokenDto> LoginDingTalkAsync(string appName, string code);

    }
}