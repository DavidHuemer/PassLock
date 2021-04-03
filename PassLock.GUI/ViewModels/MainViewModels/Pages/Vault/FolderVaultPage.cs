using PassLock.Bitwarden.Data.Data.Objects.Folders;
using PassLock.Bitwarden.Data.Data.Objects.Items;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages.Vault
{
    public class FolderVaultPage : BaseVaultPage
    {
        private BitwardenFolder folder;

        public FolderVaultPage(BitwardenFolder folder) : base(folder.Name, "FolderIcon")
        {
            this.folder = folder;
        }

        protected override List<BitwardenItem> GetItemsForPage(ObservableCollection<BitwardenItem> allItems)
        {
            return allItems
                .Where(x => x.FolderId != null && x.FolderId == folder.Id)
                .ToList();
        }
    }
}
