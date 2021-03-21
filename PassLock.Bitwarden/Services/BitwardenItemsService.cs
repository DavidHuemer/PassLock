using PassLock.Bitwarden.Handler.BitwardenCommandLine;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Handler.CommandLineHandler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Services
{
    public class BitwardenItemsService : IItemsService
    {
        public const string BW_SYNC_COMMAND = "bw sync";
        public const string BW_LOAD_ITEMS_COMMAND = "bw list items";

        public Task<CommandResult> LoadItems()
        {
            var result = BitwardenCLIHandler.RunCommandAsync(BW_LOAD_ITEMS_COMMAND);
            return result;
        }

        public Task<CommandResult> Sync()
        {
            var result = BitwardenCLIHandler.RunCommandAsync(BW_SYNC_COMMAND);
            return result;
        }
    }
}
