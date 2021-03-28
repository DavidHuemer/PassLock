using PassLock.Bitwarden.Handler.BitwardenCommandLine;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Handler.CommandLineHandler.Data;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Services.ObjectServices
{
    public class BitwardenFoldersService : IBitwardenObjectsService
    {
        public const string BW_LOAD_FOLDERS_COMMAND = "bw list folders";

        public async Task<CommandResult> LoadItems()
        {
            var result = await BitwardenCLIHandler.RunCommandAsync(BW_LOAD_FOLDERS_COMMAND);
            return result;
        }
    }
}
