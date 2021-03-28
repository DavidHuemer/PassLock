using PassLock.Bitwarden.Handler.BitwardenCommandLine;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Handler.CommandLineHandler.Data;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Services.ObjectServices
{
    public class BitwardenItemsService : IBitwardenObjectsService
    {
        public const string BW_LOAD_ITEMS_COMMAND = "bw list items";

        public Task<CommandResult> LoadItems()
        {
            var result = BitwardenCLIHandler.RunCommandAsync(BW_LOAD_ITEMS_COMMAND);
            return result;
        }
    }
}
