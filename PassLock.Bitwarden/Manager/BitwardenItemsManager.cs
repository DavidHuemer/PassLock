using PassLock.Bitwarden.Data.Data.Items;
using PassLock.Bitwarden.Handler.Items;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Handler.CommandLineHandler.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Manager
{
    public class BitwardenItemsManager
    {
        private static readonly ObservableCollection<BitwardenItem> bitwardenItems = new ObservableCollection<BitwardenItem>();

        private static BitwardenItemsLoader itemsLoader;

        public static void Init(IItemsService itemsService)
        {
            System.Console.WriteLine("Init BitwardenItemsManager");
            itemsLoader = new BitwardenItemsLoader(itemsService);
        }

        public static ObservableCollection<BitwardenItem> GetStoredItems()
        {
            return bitwardenItems;
        }

        public static async Task<ObservableCollection<BitwardenItem>> SyncAndLoad()
        {
            await Sync();
            var items = await LoadItems();
            return items;
        }

        public static async Task<CommandResult> Sync()
        {
            return await itemsLoader.Sync();
        }

        public static async Task<ObservableCollection<BitwardenItem>> LoadItems()
        {
            await itemsLoader.UpdateItems(bitwardenItems);
            return bitwardenItems;
        }
    }
}
