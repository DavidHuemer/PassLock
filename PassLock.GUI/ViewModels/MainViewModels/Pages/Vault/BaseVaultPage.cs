using MVVM.Tools;
using PassLock.Bitwarden.Data.Data.Objects.Items;
using PassLock.Bitwarden.Data.Data.Repositories;
using PassLock.GUI.Manager.Items;
using PassLock.GUI.ViewModels.Basics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages.Vault
{
    public abstract class BaseVaultPage : PageViewModel
    {
        public BaseVaultPage(string name, string iconsResource) : base(name, iconsResource)
        {
            DisplayName = name;
            BitwardenItemsRepository.Instance.PropertyChanged += Rep_PropChanged;
            ItemsCount = 0;

            UpdateItemsFull();
        }

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
