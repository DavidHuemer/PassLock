using System;
using System.Threading.Tasks;
using PassLock.Bitwarden.Data.Data.Repositories;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Bitwarden.Services.ObjectServices;
using PassLock.Handler.CommandLineHandler.Data;

namespace PassLock.Bitwarden.Manager.Objects
{
    public static class BitwardenVaultManager
    {
        private static IBitwardenVaultService vault;

        /// <summary>
        /// Inits the repositories
        /// </summary>
        /// <param name="itemsService">The itemsService</param>
        /// <param name="foldersService">The foldersService</param>
        public static void Init(IBitwardenVaultService vaultService, IBitwardenObjectsService itemsService, IBitwardenObjectsService foldersService)
        {
            vault = vaultService;
            BitwardenItemsRepository.Instance.Init(itemsService);
            BitwardenFoldersRepository.Instance.Init(foldersService);
        }

        public static async Task<CommandResult> SyncAsync()
        {
            return await vault.Sync();
        }
    }
}
