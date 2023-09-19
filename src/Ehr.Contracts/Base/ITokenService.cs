using System.Threading.Tasks;

namespace Ehr.Contracts.Base
{
    public interface ITokenService
    {
        Task<string> CreateToken(string userName, string[] roles);
    }
}