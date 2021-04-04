using PassLock.Bitwarden.Data.Data.Objects.Items;
using PassLock.GUI.ViewModels.Basics;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Vault.ContentViewModels.Basics;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Vault.ContentViewModels.CreationViewModels;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Vault.ContentViewModels.ItemViewers;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages.Vault.ContentViewModels
{
    public class VaultContentViewModel : BaseViewModel
    {
        //The real content of the selected or new item
        public BaseVaultContentViewModel ContentViewModel { get; set; }

        public BitwardenItem BitwardenItem { get; set; }

        public VaultContentViewModel()
        {

        }

        /// <summary>
        /// Adds a new
        /// </summary>
        public void Add()
        {
            ContentViewModel = new BitwardenItemCreationViewModel();
        }

        public void Show(BitwardenItem bitwardenItem)
        {
            BitwardenItem = bitwardenItem;
            ContentViewModel = new LoginItemViewModel();
        }
    }
}
