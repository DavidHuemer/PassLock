using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Handler.CommandLineHandler;
using PassLock.Handler.CommandLineHandler.Data;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Services
{
    public class BitwardenAuthService : IAuthService
    {
        public const string BW_STATUS_COMMAND = "bw status";
        public const string BW_LOGIN_COMMAND = "bw login";
        public const string BW_LOGOUT_COMMAND = "bw logout";
        public const string BW_UNLOCK_COMMAND = "bw unlock";
        public const string BW_LOCK_COMMAND = "bw lock";
        public const string BW_SET_SESSION_COMMAND = "set BW_SESSION=";


        public async Task<CommandResult> GetAuthStatus()
        {
            var result = await CommandHandler.RunCommandAsync(BW_STATUS_COMMAND);
            return result;
        }

        public async Task<CommandResult> Lock()
        {
            var result = await CommandHandler.RunCommandAsync(BW_LOCK_COMMAND);
            return result;
        }

        public async Task<CommandResult> Login(string username, string password)
        {
            string encapsulatedUsername = CommandHandler.EncapsulateString(username);
            string encapsulatedPassword = CommandHandler.EncapsulateString(password);

            string command = $"{BW_LOGIN_COMMAND} {encapsulatedUsername} {encapsulatedPassword}";
            var result = await CommandHandler.RunCommandAsync(command);
            return result;
        }

        public async Task<CommandResult> Logout()
        {
            var result = await CommandHandler.RunCommandAsync(BW_LOGOUT_COMMAND);
            return result;
        }

        public async Task<CommandResult> Unlock(string password)
        {
            string encapsulatedPassword = CommandHandler.EncapsulateString(password);
            string command = $"{BW_UNLOCK_COMMAND} {encapsulatedPassword}";
            var result = await CommandHandler.RunCommandAsync(command);
            return result;
        }
    }
}
