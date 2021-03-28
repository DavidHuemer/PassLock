using PassLock.Bitwarden.Handler.BitwardenCommandLine;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Handler.CommandLineHandler.Data;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Services
{
    /// <summary>
    /// Handles the general vault commands
    /// </summary>
    public class BitwardenVaultService : IBitwardenVaultService
    {
        public const string BW_SYNC_COMMAND = "bw sync";

        /// <summary>
        /// Syncs the vault
        /// </summary>
        /// <returns>The result of the sync command</returns>
        public Task<CommandResult> Sync()
        {
            var result = BitwardenCLIHandler.RunCommandAsync(BW_SYNC_COMMAND);
            return result;
        }
    }
}
