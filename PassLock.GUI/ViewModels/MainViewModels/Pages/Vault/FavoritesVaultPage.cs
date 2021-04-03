using PassLock.Bitwarden.Data.Data.Objects.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages.Vault
{
    public class FavoritesVaultPage : BaseVaultPage
    {
        public FavoritesVaultPage() : base("Favorites", "FavoritesIcon")
        {

        }

        protected override List<BitwardenItem> GetItemsForPage(ObservableCollection<BitwardenItem> allItems)
        {
            return allItems
                .Where(x => x.Favorite)
                .ToList();
        }
    }
}
