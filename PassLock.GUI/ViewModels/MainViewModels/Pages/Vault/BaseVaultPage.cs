using MVVM.Tools;
using PassLock.Bitwarden.Data.Data.Objects.Items;
using PassLock.Bitwarden.Data.Data.Repositories;
using PassLock.GUI.Manager.Items;
using PassLock.GUI.ViewModels.Basics;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Vault.ContentViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages.Vault
{
    public abstract class BaseVaultPage : PageViewModel
    {
        public BaseVaultPage(string name, string iconsResource) : base(name, iconsResource)
        {
            VaultContent = new VaultContentViewModel();
            BitwardenItemsRepository.Instance.PropertyChanged += Rep_PropChanged;
            ItemsCount = 0;

            UpdateItemsFull();
        }

        #region Properties

        public VaultContentViewModel VaultContent { get; set; }

        public List<BitwardenItem> VaultItems { get; set; }

        public List<BitwardenItem> DisplayItems { get; set; } = new List<BitwardenItem>();

        private string searchText = "";
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                UpdateItems();
            }
        }

        private BitwardenItem selectedItem;

        public BitwardenItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                VaultContent.Show(selectedItem);
            }
        }

        #endregion

        #region Commands

        public RelayCommand AddItem => new RelayCommand(o => { DoAddItem(); }, o => true);

        private void DoAddItem()
        {
            VaultContent.Add();
        }

        #endregion

        private void Rep_PropChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BitwardenItemsRepository.Items))
            {
                UpdateItemsFull();
            }
        }

        private void UpdateItemsFull()
        {
            VaultItems = GetItemsForPage(BitwardenItemsRepository.Instance.Items);
            UpdateItems();
            ItemsCount = VaultItems.Count;
        }

        private void UpdateItems()
        {
            DisplayItems = ItemsSearchManager.FilterItems(VaultItems, searchText);
        }

        protected abstract List<BitwardenItem> GetItemsForPage(ObservableCollection<BitwardenItem> allItems);
    }
}
