using Newtonsoft.Json;
using PassLock.Bitwarden.Data.Data.Objects.Items;
using PassLock.Bitwarden.Data.DTOs.Objects.Items;
using PassLock.Handler.CommandLineHandler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Data.Data.Repositories
{
    /// <summary>
    /// Represents the bitwarden vault
    /// </summary>
    public class BitwardenItemsRepository : BaseRepository<BitwardenItem>
    {
        #region Singleton

        private static BitwardenItemsRepository instance;
        public static BitwardenItemsRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new BitwardenItemsRepository();
                return instance;
            }
        }

        private BitwardenItemsRepository()
        {

        }

        #endregion

        public override async Task<List<BitwardenItem>> LoadItems()
        {
            var result = await service.LoadItems();
            if (result.Status != CommandStatus.Success)
                throw new ArgumentException($"Error loading folders: {result.Output}");

            var dtos = JsonConvert.DeserializeObject<List<BitwardenItemDTO>>(result.Output);
            return dtos.Select(x => x.ConvertBack()).ToList();
        }

        public async Task UpdateItems(bool loadIcons = true)
        {
            await base.UpdateItems();
            if (loadIcons)
            {
                Console.WriteLine("Icons");
            }
        }
    }
}
