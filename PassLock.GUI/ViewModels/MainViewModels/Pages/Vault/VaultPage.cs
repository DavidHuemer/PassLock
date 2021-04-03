using PassLock.Bitwarden.Data.Data.Objects.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages.Vault
{
    public class VaultPage : BaseVaultPage
    {
        public VaultPage(string name) : base(name, "AllItemsIcon")
        {

        }

        protected override List<BitwardenItem> GetItemsForPage(ObservableCollection<BitwardenItem> allItems)
        {
            return allItems.ToList();
        }
    }
}
