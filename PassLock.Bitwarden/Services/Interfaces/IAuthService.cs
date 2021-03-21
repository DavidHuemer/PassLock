using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Handler.CommandLineHandler.Data;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Services.Interfaces
{
    public interface IAuthService
    {
        Task<CommandResult> GetAuthStatus();

        Task<CommandResult> Login(string username, string lastname);

        Task<CommandResult> Logout();

        Task<CommandResult> Unlock(string sessionKey);

        Task<CommandResult> Lock();
    }
}
