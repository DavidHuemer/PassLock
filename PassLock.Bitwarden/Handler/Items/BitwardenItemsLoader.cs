using Newtonsoft.Json;
using PassLock.Bitwarden.Converter;
using PassLock.Bitwarden.Data.Data.Items;
using PassLock.Bitwarden.Data.DTOs.Items;
using PassLock.Bitwarden.Handler.Items.Icons;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Handler.CommandLineHandler.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Handler.Items
{
    public class BitwardenItemsLoader
    {
        private readonly IItemsService itemsService;

        public BitwardenItemsLoader(IItemsService itemsService)
        {
            this.itemsService = itemsService;
        }

        public async Task<CommandResult> Sync()
        {
            var result = await itemsService.Sync();
            return result;
        }

        public async Task<List<BitwardenItem>> UpdateItems(ObservableCollection<BitwardenItem> bitwardenItems)
        {
            bitwardenItems.Clear();

            var items = await LoadItems();
            foreach (var item in items)
            {
                bitwardenItems.Add(item);
            }

            BitwardenIconsHandler.StartItemsGetterThread(bitwardenItems);

            return items;
        }

        private async Task<List<BitwardenItem>> LoadItems()
        {
            try
            {
                var itemDTOs = await GetItemDTOs();
                var items = BitwardenItemsDTOConverter.ConvertyItemsByDTOs(itemDTOs);
                return items;
            }
            catch (JsonException jsonEx)
            {
                System.Console.WriteLine(jsonEx);
                return new List<BitwardenItem>();
            }
        }

        private async Task<List<BitwardenItemDTO>> GetItemDTOs()
        {
            var result = await itemsService.LoadItems();
            var dtos = JsonConvert.DeserializeObject<List<BitwardenItemDTO>>(result.Output);
            return dtos;
        }
    }
}
