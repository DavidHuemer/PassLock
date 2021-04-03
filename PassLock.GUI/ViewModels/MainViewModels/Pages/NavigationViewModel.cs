using MVVM.Tools;
using PassLock.Bitwarden.Data.Data.Objects.Items;
using PassLock.Bitwarden.Data.Data.Repositories;
using PassLock.GUI.ViewModels.Basics;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Account;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Settings;
using PassLock.GUI.ViewModels.MainViewModels.Pages.Vault;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PassLock.GUI.ViewModels.MainViewModels.Pages
{
    /// <summary>
    /// Handles the navigation on the MainWindow
    /// </summary>
    public class NavigationViewModel : BaseViewModel
    {
        #region Properties

        #region Vault

        public VaultPage AllItems { get; set; }
        public FavoritesVaultPage FavoriteItems { get; set; }
        public List<CategoryVaultPage> CategoryItems { get; set; } = new List<CategoryVaultPage>();
        public List<FolderVaultPage> Folders { get; set; } = new List<FolderVaultPage>();

        #endregion

        public SettingsPageViewModel Settings { get; set; }
        public AccountPageViewModel Account { get; set; }

        public PageViewModel CurrentPage { get; set; }

        #endregion

        public NavigationViewModel()
        {
            AllItems = new VaultPage("All items");
            FavoriteItems = new FavoritesVaultPage();
            CategoryItems.Add(new CategoryVaultPage("Login", "LoginIcon", typeof(LoginItem)));
            CategoryItems.Add(new CategoryVaultPage("Note", "NoteIcon", typeof(NoteItem)));
            CategoryItems.Add(new CategoryVaultPage("Card", "CardIcon", typeof(CardItem)));
            CategoryItems.Add(new CategoryVaultPage("Identity", "IdentityIcon", typeof(IdentityItem)));

            Settings = new SettingsPageViewModel();
            Account = new AccountPageViewModel();

            UpdateFolders();

            BitwardenFoldersRepository.Instance.PropertyChanged += Folders_PropChanged;
        }

        private void Folders_PropChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(BitwardenFoldersRepository.Items))
            {
                UpdateFolders();
            }
        }

        private void UpdateFolders()
        {
            var folders = BitwardenFoldersRepository.Instance.Items;
            foreach (var folder in folders)
            {
                Folders.Add(new FolderVaultPage(folder));
            }
        }

        public RelayCommand<PageViewModel> ChangePage => new RelayCommand<PageViewModel>(o => { DoChangePage(o); }, o => true);

        private void DoChangePage(PageViewModel o)
        {
            Console.WriteLine($"Change current page to {o.DisplayName}");
            CurrentPage = o;
        }
    }
}
